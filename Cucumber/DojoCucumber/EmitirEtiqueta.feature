# language: pt

Funcionalidade: Emitir Etiqueta
 
Cenario: Etiqueta emitida com sucesso
	Dado que eu estou na pagina do enderecador
	Quando eu preencher o CEP "82030340" na tela com o nome "Dina S/A" com a promo "promo" com o numero "165"
	E clicar no botao
	Entao a etiqueta deve ser emitida