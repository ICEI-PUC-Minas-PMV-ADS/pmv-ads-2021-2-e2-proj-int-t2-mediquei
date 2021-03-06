# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Para que o projeto em desenvolvimento seja efetivo e resolutivo quanto às demandas dos usuários, foram levantadas, por meio de brainstorming, os desejos e frustrações dos usuários. Esses dados coletados foram explicitados na forma de personas para auxiliar no desenho do projeto.

## Personas

As personas levantadas durante o processo de entendimento do problema são apresentadas nas figuras que se seguem. Elas são um cuidador, um paciente sem limitações ou necessidades especiais, um familiar de paciente idoso, uma paciente idosa, um paciente surdo e uma gestante.

| nº |NOME| IDADE  |OCUPAÇÃO |DESCRIÇÃO| PLTAFORMAS UTILIZADAS | MOTIVAÇÕES| FRUSTAÇÔES| HOBBIES|
|---|----|-------|-----------|--------|-----------------------|------------|----------|---------|
| 01 | Paulo Fontes| 40 anos | Analista de Vendas| Pessoa em tratamento de doença crônica de pele.|	Instagram, Netflix, Amazon Prime, Uber, Ifood, Spotify|	Utilizar o website para documentar e arquivar os medicamentos utilizados durante os vários períodos de tratamento,Entender quais medicamentos tiveram melhor efetividade no tratamento.|Dificuldade de arquivar todos os tratamentos já realizados.|Ler jornal, séries, Taekwondo, Toca bateria em uma banda.|
| 02 |Carlos Tobias| Idade: 45| Cuidador| Cuidador que acompanhar vários idosos com diferentes comorbidades e cuidados.| Instagram, Facebook, Uber, Ifood, Spotify, Jogos onlime| Auxiliar o paciente na administração e controle de medicamentos| Dificuldade no controle de horários de medicamentos.| História, Filmes e séries, Pintura.|
|03|Flávia Santos| 30 anos| Analista de Sistemas | Filha de paciente em tratamento médico| Instagram, Github, Visual Studio, LinkedIn | Aompanhar os horários e a correta ministração dos remédios por emio do relatório do website.	|Dificuldades no acompanhamento dos horários dos medicamentos| Programar apps, adora ir ao cinema, Ciclismo!
|04|Sebastiana Silva| 76 anos| Aposentada| Idosa com baixa visão em tratamento médico de pressão alta e diabetes.|	WhatsApp, Facebook.| Organizar quais remédios estão sendo ministrados e lembrar quais os horários devem ser tomados. Compartilhar, com seus familiares e cuidadores, o histórico de tratamentos.| Dificuldade de organizar e lembrar quais remédios devem ser utilizados | dança, Jardinagem|
|05|Maria Arino| 22 anos| Estudante| Jovem surda em tratamentos periódicos com insuficiência cardíaca.| Tinder, WhatsApp, Twitter, Ifood, Instagram, Tik Tok| 	Controlar suas medicações prescritas durante o tratamento médico. | Dificuldade de organizar acompanhar os horários das medicações| Matemática, Leitura, Caminhada na natureza, Yoga
|06|Joana Santos| 32 anos| Administradora de empresas| Gestante de risco do primeiro filho.|	Twitter, WhatsApp, apps de jornais, 99| Ter de forma prática quais os remédios que pode tomar, devido a gravidez.| Organizar o horário das suas vitaminas e remédios. Facilitar o feedback com a sua médica de acompanhamento da gravidez.|	Necessidade de anotar todos os efeitos dos remédios para a sua médica e conseguir tomar todos no horário certo. | Yoga, tai chi chuan, Feng shui, musculação|


## Histórias de Usuários

A partir da compreensão do dia a dia das personas identificadas para o projeto, foram registradas as seguintes histórias de usuários. 

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Eu, Paulo Pontes, como pessoa em tratamento de doença crônica de pele|	desejo cadastrar os medicamentos utilizados durante os vários períodos de tratamento aos quais já me submeti, informando a eficácia ou não do medicamento|	para saber quais medicamentos tiveram melhor efetividade no tratamento.|
|Eu, Paulo Pontes, como pessoa em tratamento de doença crônica de pele|	desejo informar os medicamentos que causaram efeito colateral durante o tratamento e quais foram esses efeitos|	Para evitar de repetir os erros de tratamentos anteriores.|
|Eu, Carlos Tobias, como cuidador|desejo receber alertas de horário, posologia e modo de administração do medicamento|	para assegurar que o paciente seja medicado nos horários e formas corretas e informar a família sobre o andamento do tratamento.|
|Eu, Carlos Tobias, como cuidador|desejo cadastrar todos os medicamentos, posologia e modo de administração do medicamento ao paciente|	para ter um guia rápido durante o processo de ministrar o medicamento.|
|Eu, Flávia Santos, como filha de paciente em tratamento|	desejo cadastrar todos os medicamentos, posologia e modo de administração do medicamento ao paciente|	para ter um guia rápido durante o processo de ministração do medicamento.|
|Eu, Flávia Santos, como filha de paciente em tratamento|desejo emitir relatório de medicamentos, períodos de tratamento| Para me informar sobre o tratamento.
|Eu, Sebastiana Silva, como idosa com baixa visão em tratamento|	Desejo que meus filhos cadastrem meus medicamentos|	Para garantir que o site fique atualizado.
|Eu, Sebastiana Silva, como idosa com baixa visão, em tratamento| Desejo receber alertas de horários de medicamentos. Desejo visualizar esses alertas com letras grandes| 	Para visualizar os alertas com mais facilidade.|
|Eu, Maria Arino, como surda realizando tratamentos periódicos|	Desejo receber alertas de horários de medicamentos. O alerta deverá ativar o modo vibrar do smartfone.	|O modo vibrar será importante para que eu não perca as mensagens de alerta.|
|Eu, Joana Santos, como gestante de risco em acompanhamento|	Desejo colocar todos os medicamentos e vitaminas que tomo em um local único|	Para que possa apresentar para a minha médica no pré-natal.|
|Eu, Joana Santos, como gestante de risco em acompanhamento|	Desejo receber alertas dos horários em que devo tomar os meus medicamentos|	Para que todo o pré-natal seja realizado da forma correta.|


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|## CADASTROS|
|RF-01|	O site deve permitir o usuário cadastrar-se com um login e senha. O login deverá ser seu endereço de e-mail.	|Alta|
|RF-02|	O site deverá sugerir senhas de fácil memorização.	|Média|
|RF-03|	O site deverá permitir validar o e-mail do usuário	|baixa|
|RF-04|	O site deve permitir o acesso do paciente cadastrado, seu cuidador e seu familiar.	|Média|
|RF-05|	O site deve possuir uma tela de cadastro de dados pessoais do paciente.	|Alta|
|RF-06|	O site deve possuir uma tela de cadastro de medicamentos.	|Alta|
|RF-07|	O site deve possuir uma tela de cadastro de doenças.	|Alta|
|RF-08|	O site deve possuir uma tela de cadastro do período de tratamento.	|Alta|
|## RELATÓRIOS|
|RF-10|	O site deve emitir relatório dos medicamentos utilizados em determinado período.|	Baixa|


### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-01 |O website deverá apresentar um layout padrão para todas as telas, podendo ser criado ou utilizado um existente 	|Alta|
|RNF-02	|O website deverá ser responsivo, permitindo a visualização em um celular de forma adequada.	|Média|
|RNF-03	|O website deverá ter uma fonte padrão para todas as escritas, com alterações apenas no tamanho.	|Alta|
|RNF-04	|O website deverá adotar uma paleta de cores adequada para criar um ambiente esteticamente agradável para o usuário.	|Alta|
|RNF-05	|O website deverá ter um bom nível de contraste entre os elementos da tela em conformidade.	|Alta|
|RNF-06	|O website deve conter uma barra de navegação de fácil uso.	|Média|
|RNF-07 |O website deve ser de fácil compreensão e utilização. |Alta| 


## Restrições

As questões que limitam a execução desse projeto e que se configuram como obrigações claras para o desenvolvimento do projeto em questão são apresentadas na tabela a seguir. 

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto será desenvolvido utilizando as linguagens básicas da Web no Front-End (HTML, CSS e JavaScript). Back-end na linguagem C# e banco de dados SQL Server |
|02|O site terá maior compatibilidade com o navegador Google Chrome, sendo recomendado o seu uso.        |
|03|Para acesso ao sistema é necessário acesso à internet estável e de boa qualidade de transmissão de dados|




