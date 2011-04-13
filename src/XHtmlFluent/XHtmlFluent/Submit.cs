namespace XHtmlFluent
{
    public class Submit : Input
    {
        public Submit(string value)
        {
            Attributes(new{ type = "submit", value = value });
        }
    }
}