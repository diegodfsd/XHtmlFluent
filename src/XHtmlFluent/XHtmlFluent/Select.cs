namespace XHtmlFluent
{
    public class Select : XControl
    {
        public Select(string name, params XControl[] xControls)
            :base("select", xControls)
        {
            Attribute("name", name);
        }
    }
}