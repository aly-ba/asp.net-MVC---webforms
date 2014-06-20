using System;
using System.Collections.Generic;
using System.Web;
using MvcMusicStore.Models;
using System.Linq;

namespace MvcMusicStore.Interfaces
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetTopSellingAlbums(int count);
        Album GetById(int id);
    }

    public class SqlAlbumRepository : IAlbumRepository
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        public virtual IEnumerable<Album> GetTopSellingAlbums(int count)
        {

            return storeDB.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        public virtual Album GetById(int id)
        {
            return storeDB.Albums.Single(album => album.AlbumId == id);
        }
    }

    public class CachedAlbumRepository : SqlAlbumRepository
    {
        private static readonly object CacheLockObject = new object();
        public override IEnumerable<Album> GetTopSellingAlbums(int count)
        {
            string cacheKey = "TopSellingAlbums-" + count;
            var result = HttpRuntime.Cache[cacheKey] as List<Album>;
            if (result == null)
            {
                lock (CacheLockObject)
                {
                    result = HttpRuntime.Cache[cacheKey] as List<Album>;
                    if (result == null)
                    {
                        result = base.GetTopSellingAlbums(count).ToList();
                        HttpRuntime.Cache.Insert(cacheKey, result, null, DateTime.Now.AddSeconds(60), TimeSpan.Zero);
                    }
                }
            }
            return result;
        }

        public override Album GetById(int id)
        {
            string cacheKey = "Album-" + id;
            var result = HttpRuntime.Cache[cacheKey] as Album;
            if (result == null)
            {
                lock (CacheLockObject)
                {
                    result = HttpRuntime.Cache[cacheKey] as Album;
                    if (result == null)
                    {
                        result = base.GetById(id);
                        HttpRuntime.Cache.Insert(cacheKey, result, null, DateTime.Now.AddSeconds(60), TimeSpan.Zero);
                    }
                }
            }
            return result;
        }

    }

}