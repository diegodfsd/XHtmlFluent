namespace XHtmlFluent
{
    public class InputText : Input
    {
        public InputText(string name)
        {
            Attributes(new {type = "text", name = name});
        }
    }
}