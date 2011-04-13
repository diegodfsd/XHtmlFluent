namespace XHtmlFluent
{
    public class H1 : XControl
    {
        public H1(string text)
            : this()
        {
            Text(text);
        }

        public H1(params XControl[] xControls)
            : base("h1", xControls)
        {
        }
    }
}