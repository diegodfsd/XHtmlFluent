namespace XHtmlFluent
{
    public class Option : XControl
    {
        public Option(string value, string text)
            :base("option", null)
        {
            Attribute("value", value);
            Text(text);
        }
    }
}