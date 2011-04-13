using System.Collections.Generic;
using System.Web.UI;
using System.IO;
using XHTML.Lib;

namespace XHtmlFluent
{
    public abstract class XControl
    {
        private readonly HtmlGeneric _control;
        private readonly IList<XControl> _children = new List<XControl>();
        private XControl _parent;

        protected XControl(string tag, params XControl[] xControls)
        {
            _control = new HtmlGeneric(tag);
            AddRange(xControls);
        }

        public XControl Add(XControl xControl)
        {
            if (xControl != null)
            {
                xControl._parent = this;
                _children
                    .Add(xControl);
            }

            return this;
        }

        public XControl AddRange(XControl[] xControls)
        {
            if(xControls != null)
            {
                foreach (XControl xControl in xControls)
                {
                    Add(xControl);
                }
            }
            return this;
        }

        public XControl Attribute(string attr, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _control.Attributes[attr] = value;
            }
            else
            {
                _control
                    .Attributes
                    .Remove(attr);
            }
            return this;
        }

        public XControl Attributes(object attributes)
        {
            foreach (var p in attributes.Properties())
            {
                if (p.Value(attributes) != null)
                {
                    Attribute(p.Name, p.Value(attributes).ToString());
                }
            }
            return this;
        }

        public XControl Text(string text)
        {
            _control.InnerText = text;
            return this;
        }

        public XControl Html(string html)
        {
            _control.InnerHtml = html;
            return this;
        }

        public override string ToString()
        {
            Build();
            return Render();
        }

        protected string Render()
        {
            var stringWriter = new StringWriter();
            var writer = new HtmlTextWriter(stringWriter);
            _control.RenderControl(writer);

            return stringWriter.ToString();
        }

        protected virtual bool SelfClose { get { return false; } }

        private void Build()
        {
            _control.SelfClose = SelfClose;
            foreach (XControl xControl in _children)
            {
                xControl.Build();
                _control
                    .Controls
                    .Add(xControl._control);
            }
        }
    }
}
