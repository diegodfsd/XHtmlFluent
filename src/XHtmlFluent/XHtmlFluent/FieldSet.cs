namespace XHtmlFluent
{
    public class FieldSet : XControl
    {
        public FieldSet(params XControl[] xControls)
            :base("fieldset", xControls)
        {
        }
    }
}