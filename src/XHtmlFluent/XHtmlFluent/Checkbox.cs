namespace XHtmlFluent
{
    public class Checkbox : Input
    {
        public Checkbox(string name, string value, string text) 
        {
            Attributes(new {type = "checkbox", name = name, value = value});
            Text(text);
        }
    }
}