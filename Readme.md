Descrição
===============

Uma lib para facilitar a criação de código Html.    
Esta lib foi baseada na nova forma de escrever xml a partir do .Net Framework 3.5, onde usamos as classe:



* XDocument
* XElement
* XDeclaration

**Exemplo**

*Criação de um div com dois p dentro do div.*    

`XControl div = new Div("container", "css-class", new P(), new P());`    
`XControl div = new Div("container", "css-class")`
`.Add(new P())`
`.Add(new P());`    


*Criação de um link*    

`XControl anchor = new A("www.google.com", "google").Attributes({ @class = "css-class", target = "_blank" });`    


*Criação de um link com imagem*    
`XControl anchor = new A("www.google.com", "google").Attributes({ @class = "css-class", target = "_blank" }).Add(new Img("imagens/logo.gif", "alt"));` 