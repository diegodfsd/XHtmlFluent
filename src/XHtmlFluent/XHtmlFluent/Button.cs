namespace XHtmlFluent
{
    public class Button : Input
    {
        public Button(string label)
        {
            Attributes(new{ type = "button", value = label });
        }
    }
}