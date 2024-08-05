<h1 align="center">Gerenciamento Financeiro</h1>

### :books: Descrição

<p>Projeto da disciplina DM106 - Desenvolvimento de Web Services com segurança sob plataforma .NET </p>
<p>O projeto foi criado e projetado baseando-se na disciplina, a ideia principal foi a criação de uma API que proporciona indicativos gerais sobre Gestão pessoal de finanças</p>


#### Projeto
- As ferramentas para a construção do web service foram a linguagem C#, junto ao framework .NET Core..


### :computer: Funcionalidades dos Projetos
#### Funcionalidades
Através desta API temos acesso a endpoints relacionados com o contexto de gerenciamento financeiro. Onde podemos realizar operações com usuários, contas, transações e investimentos. Sendo assim, temos conectados e disponiveis na API os seguintes endpoints
<h2>Endpoints</h2>
<h3>Usuários</h3>

| Endpoint |Metodo| Descrição |
|---|---|---|
| `/Usuarios` | POST |Usado para a criação de usuários|
| `/Usuarios` | GET |Usado para a recuperação de todos usuários|
| `/Usuarios/{id}` | GET|Usado para a recuperação de um usuário especifico|
| `/Usuarios/{id}/contas` | GET |Usado para a recuperação das contas de um usuário especifico|
| `/Usuarios`|PUT |Usado para a atualização das informações de um usuário|
| `/Usuarios`| DELETE |Usado para a remoção de um usuário|
<h3>Contas</h3>

| Endpoint |Metodo| Descrição |
|---|---|---|
| `/Contas` | POST |Usado para a criação de uma conta|
| `/Contas` | GET |Usado para a recuperação de todos as contas|
| `/Contas/{id}` | GET|Usado para a recuperação de uma conta especifica|
| `/Contas`|PUT |Usado para a atualização das informações de uma conta|
| `/Contas/{id}`| DELETE |Usado para a remoção de uma conta|
<h3>Transações</h3>

| Endpoint |Metodo| Descrição |
|---|---|---|
| `/Transacao`     | POST |Usado para a criação de uma transação de uma conta|
| `/Transacao`     | GET  |Usado para a recuperação de todas as transações|
| `/Transacao`     |PUT   |Usado para a atualização das informações de uma transação|
| `/Transacao/{id}`| DELETE |Usado para a remoção de uma transação|
<h3>Investimentos</h3>

| Endpoint |Metodo| Descrição |
|---|---|---|
|`/Investimentos` | POST |Usado para a criação de investimentos|
|`/Investimentos` | GET |Usado para a recuperação de todos investimentos|
|`/Investimentos/{id}/contas` | GET |Usado para a recuperação das contas de um investimentos especifico|
|`/Investimentos`|PUT |Usado para a atualização das informações de um investimento|
|`/Investimentos`| DELETE |Usado para a remoção de um investimento|

### :hammer_and_wrench: Ferramentas utilizadas
#### Preparação do ambiente no computador para executar a API
- [Visual Studio](https://git-scm.com/)

## :gear: Autor

* **Gabriel Ilian Fonseca Barboza** - [Gabriel](https://github.com/G-ilian) 
