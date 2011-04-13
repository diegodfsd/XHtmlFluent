namespace XHtmlFluent
{
    public class A : XControl
    {
        public A(string href, params XControl[] xControls)
            : this(href, string.Empty, xControls)
        {
        }

        public A(string href, string text, params XControl[] xControls)
            : base("a", xControls)
        {
            Attribute("href", href);
            Text(text);
        }
    }
}
