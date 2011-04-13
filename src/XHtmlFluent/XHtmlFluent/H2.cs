namespace XHtmlFluent
{
    public class H2 : XControl
    {
        public H2(string text)
            : this()
        {
            Text(text);
        }

        public H2(params XControl[] xControls)
            : base("h2", xControls)
        {
        }
    }
}