using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace XHtmlFluent
{
    public class HtmlGeneric : HtmlGenericControl
    {
        public HtmlGeneric(string tag) :base(tag)
        {
            SelfClose = true;
        }

        public bool SelfClose { get; set; }

        protected override void Render(HtmlTextWriter writer)
        {
            if(SelfClose)
            {
                RenderSelfClose(writer);
            }
            else
            {
                base.Render(writer);    
            }
        }

        private void RenderSelfClose(HtmlTextWriter writer)
        {
            writer.WriteBeginTag(TagName);
            RenderAttributes(writer);
            writer.Write(HtmlTextWriter.SelfClosingTagEnd);
            RenderChildren(writer);           
        }
    }
}