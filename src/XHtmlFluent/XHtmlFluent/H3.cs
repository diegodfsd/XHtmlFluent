namespace XHtmlFluent
{
    public class H3 : XControl
    {
        public H3(string text)
            : this()
        {
            Text(text);
        }

        public H3(params XControl[] xControls)
            : base("h3", xControls)
        {
        }
    }
}