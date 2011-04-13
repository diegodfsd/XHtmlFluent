namespace XHtmlFluent
{
    public class H4 : XControl
    {
        public H4(string text)
            : this()
        {
            Text(text);
        }

        public H4(params XControl[] xControls)
            : base("h4", xControls)
        {
        }
    }
}