namespace XHtmlFluent
{
    public class Legend : XControl
    {
        public Legend(string title) 
            :base("legend", null)
        {
            Text(title);
        }
    }
}