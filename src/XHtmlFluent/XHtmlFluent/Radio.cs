namespace XHtmlFluent
{
    public class Radio : Input
    {
        public Radio(string name, string value, string text)
        {
            Attributes(new { type = "radio", name = name, value = value });
            Text(text);
        }
    }
}