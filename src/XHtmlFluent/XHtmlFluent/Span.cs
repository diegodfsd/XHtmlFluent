namespace XHtmlFluent
{
    public class Span :XControl
    {
        public Span(string text)
            : this()
        {
            Text(text);
        }

        public Span(params XControl[] xControls) 
            : base("span", xControls)
        {
        }
    }
}