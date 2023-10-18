 # confitec-users-api
 API para teste da Confitec

 Antes de rodar, execute a configuração inicial.

 ## Configuração inicial

  Subir o SQL Server
 ```bash
 docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=x#D7F8@p2!A6' -p 1433:1433 --name sql_server_container -d mcr.microsoft.com/mssql/server:2019-latest
 ```

  Configurar o SQL Server
 - Criar o Database = Confitec
 - Criar o usuário confitec-user com a senha C0nf!t3cUs3rP@ss
 - Garantir que o usuário confitec-user tenha privilégios de db_owner

 ## Subir a API
 - Utilize o comando 'dotnet run' no VS Code ou
 - Execute o projeto no Visual Studio
