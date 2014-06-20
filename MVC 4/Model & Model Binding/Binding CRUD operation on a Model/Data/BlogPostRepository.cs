using Lesson09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Lesson09.Data
{
    public class BlogPostRepository
    {
        private string _documentPath;
        private XDocument _document;

        public BlogPostRepository()
        {
            _documentPath = HttpContext.Current.Server.MapPath("~/App_Data/BlogDataStore.xml");
            _document = XDocument.Load(_documentPath);
            LoadData();
        }

        #region Helpers
        private IEnumerable<BlogPost> LoadData()
        {
            var posts = _document.Root.Elements("blogPost")
                .Select(el => ConvertElementToBlogPost(el));

            return posts;
        }

        private XElement ConvertBlogPostToElement(BlogPost post)
        {
            XElement el = new XElement("blogPost",
                    new XAttribute("id", post.Id),
                    new XElement("created", post.Created),
                    new XElement("title", post.PostTitle),
                    new XElement("message", post.PostMessage)
            );

            return el;
        }

        private BlogPost ConvertElementToBlogPost(XElement element)
        {
            return new BlogPost()
            {
                Id = Convert.ToInt32(element.Attribute("id").Value),
                Created = DateTime.Parse(element.Element("created").Value),
                PostTitle = element.Element("title").Value,
                PostMessage = element.Element("message").Value
            };
        }

        private XElement GetElementById(int id)
        {
            return (from el in _document.Root.Elements("blogPost")
                    where el.Attribute("id").Value == id.ToString()
                    select el).SingleOrDefault();
        }

        #endregion

        public IEnumerable<BlogPost> GetRecentPosts()
        {
            return LoadData()
                .OrderByDescending(p => p.Created)
                .ToArray();
        }

        public int Insert(BlogPost post)
        {
            var id = LoadData().Max(p => p.Id) + 1;

            post.Id = id;

            _document.Root.Add(ConvertBlogPostToElement(post));

            _document.Save(_documentPath);

            return id;
        }

        public void Edit(BlogPost post)
        {
            var el = GetElementById(post.Id);

            if (el == null)
                return;

            el.Element("created").Value = post.Created.ToString();
            el.Element("title").Value = post.PostTitle;
            el.Element("message").Value = post.PostMessage;

            _document.Save(_documentPath);
        }

        public bool Delete(BlogPost post)
        {
            var el = GetElementById(post.Id);

            if (el == null) 
                return false;

            el.Remove();

            _document.Save(_documentPath);

            return true;
        }

        public BlogPost GetById(int id)
        {
            var el = GetElementById(id);

            if (el == null)
                return null;

            return el != null ? ConvertElementToBlogPost(el) : null;
        }
    }
}