Descri��o
===============

Uma lib para facilitar a cria��o de c�digo Html.    
Esta lib foi baseada na nova forma de escrever xml a partir do .Net Framework 3.5, onde usamos as classe:



* XDocument
* XElement
* XDeclaration

**Exemplo**

*Cria��o de um div com dois p dentro do div.*    

`XControl div = new Div("container", "css-class", new P(), new P());`    
`XControl div = new Div("container", "css-class")`
`.Add(new P())`
`.Add(new P());`    


*Cria��o de um link*    

`XControl anchor = new A("www.google.com", "google").Attributes({ @class = "css-class", target = "_blank" });`    


*Cria��o de um link com imagem*    
`XControl anchor = new A("www.google.com", "google").Attributes({ @class = "css-class", target = "_blank" }).Add(new Img("imagens/logo.gif", "alt"));` 