namespace XHtmlFluent
{
    public class Img : XControl
    {
        public Img(string src, string alt)
            : base("img", null)
        {
            Attribute("src", src);
            Attribute("alt", alt);
        }

        protected override bool SelfClose
        {
            get { return true; }
        }
    }
}
