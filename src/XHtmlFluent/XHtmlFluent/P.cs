namespace XHtmlFluent
{
    public class P : XControl
    {
        public P()
            : this(null)
        { 
        }

        public P(string cssClass)
            : this("p", null)
        {
            Attribute("class", cssClass);
        }

        public P(string cssClass, params XControl[] xControls)
            : base("p", xControls)
        {
            Attribute("class", cssClass);
        }
    }
}
