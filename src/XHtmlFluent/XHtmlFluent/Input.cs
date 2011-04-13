namespace XHtmlFluent
{
    public  class Input : XControl
    {
        protected Input() 
            : base("input")
        {
        }

        protected override bool SelfClose
        {
            get { return true; }
        }
    }
}