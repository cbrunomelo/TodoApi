# To do Api
Uma Api onde usuários podem registrar as suas tarefas <br>
link da hospedagem: https://api-todo.azurewebsites.net/swagger/index.html <br>
usuário com admin: bruno@email.com senha: 123

## Modelagem Lógica
  Tipo de notação: Engenharia - Informações <br>
  <strong>Exclusões de tuplas</strong> <br>
  User -> Se uma tuplas no User for excluída, as suas tuplas correspondente em 'Todo' e 'UserRole' também serão removidas. <br>
  Todo/UserRole -> Ja uma tupla em 'Todo' e 'UserRole' se removido, as outras tabelas nao serão alteradas. <br>
  Role -> Uma tupla em 'Role' quando removida apenas a tupla correspondente em 'UserRole' será também excluida.
  
  

 <img src="https://user-images.githubusercontent.com/65568481/197024197-17488794-fc91-4457-978b-58ef9663007e.PNG">
 
## CI/CD
 Todo processo de automatização iniciado quando commit na branch main, incluso versionamento do banco de dados.
 
 
## Authentication/swagger
 Após Logar, irá receber um token no qual deve inserir no Authorize, então assim será possível o uso dos demais endpoints.


## Controllers 
 <strong>-ResultViewModel: </strong>
   Todos os endpoints tem como retorno um objeto ResultViewModel <br>
 <strong>-Injeção de dependência: </strong>
    Todas controllers tem dependência de uma abstração, das quais essas interfaces estão na pasta contracts. E então em Repositories estão as suas implementações
