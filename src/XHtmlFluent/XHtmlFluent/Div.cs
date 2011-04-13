namespace XHtmlFluent
{
    public class Div : XControl
    {
        public Div()
            : this(null)
        { 
        }

        public Div(string id)
            : this(id, string.Empty)
        {
        }

        public Div(string id, string cssClass)
            : this(new {id, @class = cssClass }, null)
        {
        }

        public Div(object attributes, params XControl[] xControls)
            : base("div", xControls)
        {
            Attributes(attributes);
        } 
    }
}
