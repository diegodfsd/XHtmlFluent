using System.IO;
using System.Web.UI;
using NUnit.Framework;
using XHtmlFluent;

namespace XHTML.Test
{
    [TestFixture]
    public class ControlTest
    {
        [Test]
        public void Div_Quando_Crio_Sem_Atributos_Sem_Filhos()
        {
            XControl div = new Div("container");

            Assert.AreEqual("<div id=\"container\"></div>", div.ToString());
        }

        [Test]
        public void Div_Quando_Crio_Com_Atributo_Class_Sem_Filhos()
        {
            XControl div = new Div("container", "css-class");

            Assert.AreEqual("<div id=\"container\" class=\"css-class\"></div>", div.ToString());
        }

        [Test]
        public void Div_Quando_Crio_Com_Um_P_Filho()
        {
            XControl div = new Div(new { id = "container" }, new P().Attribute("id", "paragrafo"));

            Assert.AreEqual("<div id=\"container\"><p id=\"paragrafo\"></p></div>", div.ToString());
        }

        [Test]
        public void Div_Quando_Adiciono_2_Filhos_P()
        {
            XControl div = new Div("container")
                .Add(new P())
                .Add(new P());

            Assert.AreEqual("<div id=\"container\"><p></p><p></p></div>", div.ToString());
        }

        [Test]
        public void Img_Quando_Crio()
        {
            XControl img = new Img("imagens/logo.gif", "logo");

            Assert.AreEqual("<img src=\"imagens/logo.gif\" alt=\"logo\" />", img.ToString());
        }

        [Test]
        public void A_Quando_Crio()
        {
            XControl a = new A("www.2dsolucoes.net", "Link");

            Assert.AreEqual("<a href=\"www.2dsolucoes.net\">Link</a>", a.ToString());
        }

        [Test]
        public void A_Quando_Crio_Com_Filho_Imagem()
        {
            XControl a = new A("www.2dsolucoes.net", new Img("imagens/logo.gif", "logo"));

            Assert.AreEqual("<a href=\"www.2dsolucoes.net\"><img src=\"imagens/logo.gif\" alt=\"logo\" /></a>", a.ToString());
        }

        [Test]
        public void Span_Quando_Crio()
        {
            XControl span = new Span("valor");

            Assert.AreEqual("<span>valor</span>", span.ToString());
        }

        [Test]
        public void Span_Quando_Crio_Com_Filhos()
        {
            XControl span = new Span(new P());

            Assert.AreEqual("<span><p></p></span>", span.ToString());
        }

        [Test]
        public void H1_Quando_Crio()
        {
            XControl h1 = new H1("Titulo");
            
            Assert.AreEqual("<h1>Titulo</h1>", h1.ToString());
        }

        [Test]
        public void H1_Quando_Crio_Com_Filho_Span()
        {
            XControl h1 = new H1(new Span("titulo"));

            Assert.AreEqual("<h1><span>titulo</span></h1>", h1.ToString());
        }

        [Test]
        public void Table_Quando_Crio_Sem_Linhas()
        {
            XControl table = new Table();

            Assert.AreEqual("<table></table>", table.ToString());
        }

        [Test]
        public void Table_Quando_Crio_Com_Uma_Linha_Sem_Celular()
        {
            XControl table = new Table(new TR());

            Assert.AreEqual("<table><tr></tr></table>", table.ToString());
        }

        [Test]
        public void Table_Quando_Crio_Com_Uma_Linha_E_Uma_Celula()
        {
            XControl table = new Table(new TR(new TD()));

            Assert.AreEqual("<table><tr><td></td></tr></table>", table.ToString());            
        }

        [Test]
        public void Table_Quando_Crio_Com_THead_Uma_Linha_TBody_Uma_Linha_E_Uma_Celula_E_TFoot()
        {
            XControl table = new Table(new THead(new TR(new TH())), new TBody(new TR(new TD())), new TFoot(new TR(new TD())));

            Assert.AreEqual("<table><thead><tr><th></th></tr></thead><tbody><tr><td></td></tr></tbody><tfoot><tr><td></td></tr></tfoot></table>", table.ToString());
        }

        [Test]
        public void UL_Quando_Crio_Com_Duas_Li()
        {
            XControl ul = new Ul(new Li().Text("item 1"), new Li().Text("item 2"));

            Assert.AreEqual("<ul><li>item 1</li><li>item 2</li></ul>", ul.ToString());
        }

        [Test]
        public void Strong_Quando_Crio_Com_Filho_Span()
        {
            XControl strong = new Strong(new Span("Diego Dias"));

            Assert.AreEqual("<strong><span>Diego Dias</span></strong>", strong.ToString());
        }

        [Test]
        public void Input_Button_Quando_Crio()
        {
            XControl button = new Button("click");

            Assert.AreEqual("<input type=\"button\" value=\"click\" />", button.ToString());
        }

        [Test]
        public void FieldSet_Com_Inputs_Text_E_Checkbox_E_Radio_E_Select_E_Submit()
        {
            XControl Fieldset = new FieldSet(new Legend("Titulo"),
                                             new InputText("nome-inputtext"),
                                             new Checkbox("nome-checkbox", "0", "solteiro?"),
                                             new Radio("nome-radio", "1", "desenvolvedor"),
                                             new Select("name",
                                                 new Option("value-option", "item1"),
                                                 new Option("value-option", "item2")))
                                                 .Add(new Submit("enviar"));

            string expected = "<fieldset>";
            expected += "<legend>Titulo</legend>";
            expected += "<input type=\"text\" name=\"nome-inputtext\" />";
            expected += "<input type=\"checkbox\" name=\"nome-checkbox\" value=\"0\" />solteiro?";
            expected += "<input type=\"radio\" name=\"nome-radio\" value=\"1\" />desenvolvedor";
            expected += "<select name=\"name\">";
            expected += "<option value=\"value-option\">item1</option>";
            expected += "<option value=\"value-option\">item2</option>";
            expected += "</select>";
            expected += "<input type=\"submit\" value=\"enviar\" />";
            expected += "</fieldset>";

            Assert.AreEqual(expected, Fieldset.ToString());
        }

        [Test]
        public void GenericControl_AutoClose_Img()
        {
            HtmlGeneric selfClose = new HtmlGeneric("img"){SelfClose = true};

            Assert.AreEqual("<img />", Render(selfClose));
        }

        [Test]
        public void GenericControl_AutoClose_Checkbox_Com_Atributos_E_InnerText()
        {
            HtmlGeneric selfClose = new HtmlGeneric("input"){SelfClose = true};
            selfClose.Attributes["type"] = "checkbox";
            selfClose.Attributes["value"] = "value";
            selfClose.Attributes["name"] = "name";
            selfClose.InnerText = "text";

            Assert.AreEqual("<input type=\"checkbox\" value=\"value\" name=\"name\" />text", Render(selfClose));
        }


        private static string Render(HtmlGeneric generic)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            generic.RenderControl(htmlTextWriter);
            return stringWriter.ToString();
        }
    }
}
