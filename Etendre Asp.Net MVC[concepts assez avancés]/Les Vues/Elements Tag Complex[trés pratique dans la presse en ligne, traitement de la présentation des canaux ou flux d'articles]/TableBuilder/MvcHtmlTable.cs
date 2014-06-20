using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace LesVues.TableBuilder
{
    public    class MvcHtmlTable : IDisposable
    {
        private readonly TextWriter _writer;
        private readonly TagBuilder _builder;
        private bool _disposed;

        public TextWriter Writer
        {
            get { return _writer; }
        }


        public MvcHtmlTable(TextWriter writer, object attributes)
        {
            // TODO: Complete member initialization
            _writer = writer;

            _builder = new TagBuilder("table");

            TableHelper.MergeAttributes(_builder, attributes);

            _writer.Write(_builder.ToString(TagRenderMode.StartTag));
        }



        public MvcHtmlTable(TextWriter writer)
        {
            // TODO: Complete member initialization
            this._writer = writer;

            _builder = new TagBuilder("table");

            _writer.Write(_builder.ToString(TagRenderMode.StartTag));
        }


        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _writer.Write(_builder.ToString(TagRenderMode.EndTag));
            _disposed = true;

        }
    }
}
