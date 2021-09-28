# Plano de Testes de Usabilidade

O teste de usabilidade permite avaliar a qualidade da interface com o usuário da aplicação interativa. O Plano de Testes de Software é gerado a partir da especificação do sistema e consiste em casos de testes que deverão ser executados quando a implementação estiver parcial ou totalmente pronta.

As referências abaixo irão auxiliá-lo na geração do artefato "Plano de Testes de Usabilidade".

> **Links Úteis**:
> - [Teste De Usabilidade: O Que É e Como Fazer Passo a Passo (neilpatel.com)](https://neilpatel.com/br/blog/teste-de-usabilidade/)
> - [Teste de usabilidade: tudo o que você precisa saber! | by Jon Vieira | Aela.io | Medium](https://medium.com/aela/teste-de-usabilidade-o-que-voc%C3%AA-precisa-saber-39a36343d9a6/)
> - [Planejando testes de usabilidade: o que (e o que não) fazer | iMasters](https://imasters.com.br/design-ux/planejando-testes-de-usabilidade-o-que-e-o-que-nao-fazer/)
> - [Ferramentas de Testes de Usabilidade](https://www.usability.gov/how-to-and-tools/resources/templates.html)


# Plano de Testes de Software

Os requisitos para realização dos testes de software são:
* Site publicado na Internet
* Navegador da Internet - Chrome, Firefox ou Edge 
* Conectividade de Internet para acesso às plataformas (APISs)

Os testes funcionais a serem realizados no aplicativo são descritos a seguir.


| **Caso de Teste** |**CT-01 - Cadastrar Usuário**| 
|---|----|
|Requisitos Associados |RF-01 O site deve permitir o usuário cadastrar-se com um login e senha. O login deverá ser seu endereço de e-mail ou número do telefone celular. A senha é opcional.<br/> RF-02 O site deverá sugerir senhas de fácil memorização. Ex: os 5 primeiros dígitos do CPF.<br/> RF-05 O site deve possuir uma tela de cadastro de dados pessoais do paciente.|
|Objetivo do Teste | Verificar a possibilidade de cadastro de novos usuários|
|Passos |1) Acessar o navegador <br/> 2) Acessar o site <br/> 3) Na tela inicial clicar em "Cadastre-se"<br/> 4) Informar os campos solicitados: Nome Completo, email e senha <br/> 5) Clicar em"Cadastre-se"|
|Critérios de Êxito |Uma mensagem de sucesso deve ser exibida <br/> Os dados devem ser salvos no banco de dados e serem possíveis de acessar posteriormente|

|**Caso de Teste** |**CT-02 - Realizar Login**| 
|---|----|
|Requisitos Associados | RF-03 O site deverá permitir validar o e-mail ou telefone do usuário <br/> RF-04	O site deve permitir o acesso do paciente cadastrado, seu cuidador e seu familiar.<br/>|
|Objetivo do Teste |Verificar a possibilidade do usuário realizar o login|
|Passos |1) Acessar o navegador <br/> 2) Acessar o site <br/> 3) Na tela inicial clicar em "Acessar"<br/> 4) Informar os campos solicitados: Email e senha <br/> 5) Clicar em "Acessar" |
|Critérios de Êxito |Ao serem informados os dados cadastrados anteriormente, o usuário será direcionado para a página home |

|**Caso de Teste** |**CT-03 - Cadastrar Medicação**| 
|---|----|
|Requisitos Associados |RF-07 O site deve possuir uma tela de cadastro de medicamentos.<br/> RF-09 O site deve possuir uma tela de cadastro do período de tratamento, horário, posologia e modo de administração do medicamento para aquele paciente.|
|Objetivo do Teste | Verifica a possibilidade do usuário cadastrar e editar medicação |
|Passos |1) Acessar o navegador <br/> 2) Acessar o site <br/> 3) Na tela inicial clicar em "Acessar"<br/> 4) Realizar Login <br/> 5) Clicar em "Cadastro de Medicamentos" <br/> 6) Preencher todos os campos disponiveis <br/> 7) Clicar em "Salvar" |
|Critérios de Êxito | Caso algum campo obrigatório não for preenchido, o usuário deve ser informado sobre o campo <br/> Se todos os campos forem preenchidos e os dados salvos uma mensagem de sucesso da operação deve ser exibida <br/> Os dados cadastrados devem ser salvos no banco de dados <br/>Ao acessar "Minha agenda" o medicamento cadastrado deve ser exibido |

|**Caso de Teste** |**CT-04 - Emitir relatórios**| 
|---|----|
|Requisitos Associados |RF-13		O site deve emitir relatório dos medicamentos utilizados em determinado período. |
|Objetivo do Teste |Verificar a possibilidade do usuário emitir relatórios como os medicamento cadastrados |
|Passos |1) Acessar o navegador <br/> 2) Acessar o site <br/> 3) Na tela inicial clicar em "Acessar"<br/> 4) Realizar Login <br/> 5) Clicar em "Minha Agenda" <br/> 6) Clicar em "Exportar"|
|Critérios de Êxito |Após a exportação um arquivo pdf deve ser gerado com todas as medicações e suas informações|

|**Caso de Teste** |**CT-05 - Gerenciar acessos**| 
|---|----|
|Requisitos Associados | **Ainda sem requisitos associados** |
|Objetivo do Teste |Verificar a possibilidade do usuário gerenciar todos os perfis que acessam seus dados|
|Passos |1) Acessar o navegador <br/> 2) Acessar o site <br/> 3) Na tela inicial clicar em "Acessar"<br/> 4) Realizar Login <br/> 5) Clicar em "Gerenciamento de acessos" <br/> 6) Clicar em "Editar" e "Excluir" <br/> 7) Modificar dados cadastrados 8) Clicar em "Salvar" |
|Critérios de Êxito |Após a edição ou exclusão uma mensagem de sucesso deve ser exibida <br/> O perfil selecionado deve ser editado ou excluído do banco de dados <br/> As novas informações atualizadas do perfil editado deve aparecer na página de gerenciamento de acessos |

|**Caso de Teste** |**CT-06 - Cadastrar comorbidades**| 
|---|----|
|Requisitos Associados |RF-08 O site deve possuir uma tela de cadastro de doenças|
|Objetivo do Teste |Verificar a possibilidade de usuário cadastrar as suas comorbidades|
|Passos |1) Acessar o navegador <br/> 2) Acessar o site <br/> 3) Na tela inicial clicar em "Acessar"<br/> 4) Realizar Login <br/> 5) Clicar em "Cadastro de Comorbidade" <br/> 6) Informar todos os campos solicitados <br/> 7) Clicar em "Salvar"|
|Critérios de Êxito | Caso algum campo obrigatório não for preenchido, o usuário deve ser informado sobre o campo <br/> Uma mensagem de sucesso da operação deve ser exibida <br/> Os dados cadastrados devem ser salvos no banco de dados |
## Ferramentas de Testes (Opcional)

