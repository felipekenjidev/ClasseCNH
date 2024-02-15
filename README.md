# Classe C# para Validação de CNH
Uma Classe C# com métodos e propriedades para realizar a verificação do CNH (Carteira Nacional de Habilitação), formatando seus dígitos e indicando se o documento digitado é Verdadeiro ou Falso.

# Preparação
Antes de poder utilizar a Classe CNH, é necessário importar para dentro do projeto, colocando o próprio arquivo `clsCNH.cs` dentro do projeto ou adicionando uma referência para a DLL `clsCNH.dll`.

# Como Funciona?
Para utilizar basta instanciar a Classe CNH, passando no parâmetro o CNH a ser verificado.

`CNH variavel = new CNH("20153775851");`

Após instanciar a Classe, apenas é preciso acessar o método `Validar()` que o resultado da verificação será gerado.

`bool resposta = variavel.Validar()`
