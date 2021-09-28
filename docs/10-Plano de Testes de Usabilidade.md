# Plano de Testes de Usabilidade

O teste de usabilidade permite avaliar a qualidade da interface com o usuário da aplicação interativa. O Plano de Testes de Software é gerado a partir da especificação do sistema e consiste em casos de testes que deverão ser executados quando a implementação estiver parcial ou totalmente pronta.

Os requisitos para realização dos testes de usabilidade são:
* Conectividade de internet por dados móveis ou por banda larga;
* Navegador da Internet - Chrome, Safari, Firefox ou Edge; 
* Disponibilidade do usuário em acessar ferramentas de videoconferência com compartilhamento de tela - Zoom, Google Meet, Teams;

Os testes funcionais a serem realizados no aplicativo são descritos a seguir.


| **Caso de Teste** |**CT-01 - Forma de apresentação / Identidade da Marca**| 
|---|----|
|Requisitos Associados |RNF-01 O website deverá apresentar um layout padrão para todas as telas, podendo ser criado ou utilizado um existente. <br/> RNF-03 O website deverá ter uma fonte padrão para todas as escritas, com alterações apenas no tamanho.|
|Objetivo do Teste | Gerar uma padronização no website que fortaleça a identidade da marca. |
|Passos |1) Acessar o navegador <br/> 2) Acessar o site <br/> 3) Na tela inicial clicar em "Cadastre-se"<br/> 4) Informar os campos solicitados: Nome Completo, email e senha <br/> 5) Clicar em"Cadastre-se" <br/> 6) Na tela inicial clicar em "Acessar" <br/> 7) Informar os campos solicitados: Email e senha <br/> 8) Clicar em "Acessar" <br/> 9) Clicar dentro da tela principal em  "Precisa de ajuda? Clique Aqui" <br/> 10) Clicar em Cadastro de medicamento, dentro da barra de Menu <br/> 11) Clicar em Acessar Minha Agenda, dentro da barra de Menu <br/> 12) Clicar em Quadro de horários, dentro da barra de Menu <br/> 13) Clicar em Gerenciamento de Acessos, dentro da barra de Menu.<br/>|
|Critérios de Êxito | Validar que todas as telas estão padronizadas, com a identidade da marca bem definida. <br/> Os dados devem ser salvos no banco de dados e serem possíveis de acessar posteriormente|

|**Caso de Teste** |**CT-02 - Adequação**| 
|---|----|
|Requisitos Associados | RNF-02 O website deverá ser responsivo, permitindo a visualização em um celular de forma adequada. <br/> |
|Objetivo do Teste |Verificar a possibilidade do usuário realizar o login|
|Passos |1) Acessar o navegador <br/> 2) Acessar o site <br/> 3) Na tela inicial clicar em "Acessar"<br/> 4) Informar os campos solicitados: Email e senha <br/> 5) Clicar em "Acessar" |
|Critérios de Êxito |Ao serem informados os dados cadastrados anteriormente, o usuário será direcionado para a página home |

|**Caso de Teste** |**CT-03 - Inclusão e Acessibilidade**| 
|---|----|
|Requisitos Associados |RNF-04 O site deve possuir uma tela de cadastro de medicamentos.<br/> RNF-05 O site deve possuir uma tela de cadastro do período de tratamento, horário, posologia e modo de administração do medicamento para aquele paciente.<br/> RNF 06 - As mensagens de alerta deverão utilizar fontes de tamanho grande para facilitar a leitura por pessoas com baixa visão. <br/> RNF-09 Ao emitir um alerta de horário, o smartphone deverá vibrar para facilitar o acesso de pessoas com baixa audição ou surdas.|
|Objetivo do Teste | Verifica a possibilidade do usuário cadastrar e editar medicação <br/>|
|Passos |1) Acessar o navegador <br/> 2) Acessar o site <br/> 3) Na tela inicial clicar em "Acessar"<br/> 4) Realizar Login <br/> 5) Clicar em "Cadastro de Medicamentos" <br/> 6) Preencher todos os campos disponiveis <br/> 7) Clicar em "Salvar" |
|Critérios de Êxito | Caso algum campo obrigatório não for preenchido, o usuário deve ser informado sobre o campo <br/> Se todos os campos forem preenchidos e os dados salvos uma mensagem de sucesso da operação deve ser exibida <br/> Os dados cadastrados devem ser salvos no banco de dados <br/>Ao acessar "Minha agenda" o medicamento cadastrado deve ser exibido |

|**Caso de Teste** |**CT-04 - Intuitividade**| 
|---|----|
|Requisitos Associados |RNF-07	O site deve conter uma barra de navegação de fácil uso.<br/> |
|Objetivo do Teste |Verificar a possibilidade do usuário emitir relatórios como os medicamento cadastrados |
|Passos |1) Acessar o navegador <br/> 2) Acessar o site <br/> 3) Na tela inicial clicar em "Acessar"<br/> 4) Realizar Login <br/> 5) Clicar em "Minha Agenda" <br/> 6) Clicar em "Exportar"|
|Critérios de Êxito |Após a exportação um arquivo pdf deve ser gerado com todas as medicações e suas informações|


## Ferramentas de Testes (Opcional)

