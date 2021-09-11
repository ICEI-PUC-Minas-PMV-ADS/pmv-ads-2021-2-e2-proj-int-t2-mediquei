
# Metodologia

A metodologia contempla as definições de ferramental utilizado pela equipe tanto para a manutenção dos códigos e demais artefatos quanto para a organização do time na execução das tarefas do projeto.

## Controle de Versão

Para gestão do código fonte do software desenvolvido pela equipe, o grupo utiliza um processo baseado no Git Flow. O Git Flow é um fluxo de trabalho baseado em branchs, atribuindo funções para diferentes ramificações e definindo as suas interações. O fluxo de controle do código é exemplificado na figura abaixo. 

![image](/docs/img/gitflow.png)

As branchs são identificados como Hotfix, Release, Develop e Feature.

- `master`: irá conter todo o código já testado e que será entregue ao cliente 
- `develop`:se encontra todo o código, como recurso e funcionalidades finalizados, e posteriormente realizar o merge com a master
- ` Feature`: onde é realizada o desenvolvimento de uma funcionalidade específica, todas seguindo o mesmo padrão de nome
- `Release`: funciona com o sistema de homologação, sendo removida após a realização de testes
-  `Hotfix` é uma branch criada a partir da master, para correção após os sistemas ter entrado em produção.

## Gerenciamento de Projeto

### Divisão de Papéis

A equipe utiliza metodologias ágeis, tendo escolhido o Scrum como base para definição do processo de desenvolvimento.
A equipe está organizada da seguinte maneira:

* Scrum Master: Fernanda Salles Furtado
* Product Owner: Jaqueline Poletto 
* Equipe de Desenvolvimento:
  * Adriana Neves 
  * Ana Maria Teixeira
  * Roberta Motta 
  * Thainá Siqueira 
* Equipe de Design: 
  *Roberta Motta   

### Processo

Para acompanhar o andamento do projeto, a execução das tarefas e o status de desenvolvimento da solução, foi criado um quadro de backlogs no Github. O quadro encontra-se disponível através da URL https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2021-2-e2-proj-int-t2-mediquei/projects/1 e é apresentado, no estado atual, na figura abaixo. 

![image](/docs/img/Backlog_Github.PNG)

Para organização e distribuição das tarefas do projeto, a equipe está estruturado com as seguintes listas: 

- `Backlog`: Não está em uma coluna propriamente definida. As tarefas ficam listadas na parte do To Do e reúne todas as etapas a serem trabalhadas. Todas as atividades identificadas no decorrer do projeto também devem ser incorporadas a esta lista.

- `To Do`: Esta lista representa o Sprint Backlog. Este é o Sprint que estará sendo trabalhado no decorrer do projeto.

- `In progress`: Quando uma tarefa tiver sido iniciada, ela é movida para cá e é realizada no decorrer da Sprint.

- `Test`: Teste e checagem de Qualidade. Ao concluir tarefas, elas são movidas

para a coluna “Test”. No final da semana, é feita a revisão dessa lista com intuito de garantir que tudo saiu como planejado e sem erros.

- `Done`: Lista com as tarefas que passaram pelos testes e controle de qualidade e estão prontos para ser entregues ao usuário. Não há mais edições ou revisões a serem feitas, ele está pronto para a ação.

- `Locked`: Restrições que surgem ao desenvolver do projeto, impedindo alguma conclusão da tarefa, ela é movida para esta lista juntamente com um comentário sobre o que está travando a tarefa.
 
### Ferramentas

As ferramentas empregadas no projeto são:

|AMBIENTE| PLATAFORMA|LINK DE ACESSO|
|---------|-----------|-------------------|
|Repositório de código fonte| 	GitHub| https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2021-2-e2-proj-int-t2-mediquei|
|Gerenciamento do Projeto| 	GitHub| https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2021-2-e2-proj-int-t2-mediquei/projects/1|

- Editor de código.
- Ferramentas de comunicação
- Ferramentas de desenho de tela (_wireframing_)

O editor de código foi escolhido porque ele possui uma integração com o
sistema de versão. As ferramentas de comunicação utilizadas possuem
integração semelhante e por isso foram selecionadas. Por fim, para criar
diagramas utilizamos essa ferramenta por melhor captar as
necessidades da nossa solução.

Liste quais ferramentas foram empregadas no desenvolvimento do projeto, justificando a escolha delas, sempre que possível.
 
> **Possíveis Ferramentas que auxiliarão no gerenciamento**: 
> - [Slack](https://slack.com/)
> - [Github](https://github.com/)
