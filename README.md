# ProjetoApi

Um projeto básico de Api com fins de estudo do Asp.Net Core e C#

## Requisitos Modelagem de dados :heavy_check_mark:
- [x] Usar SqlServer;
- [x] Criar 2 tabelas usando o EF Core Usuário e Role;
- [x] Configurar relação one-to-many de usuarios e roles;
- [x] Criar o seed para popular o banco com usuarios.  

## Requisitos Endpoints :heavy_check_mark:
- [x] Ter 2 endpoints: Login e Signin;
- [x] Login deve retornar o nome do Usuario e um Token;
- [x] Token deve conter o nome e a role do usuario;
- [x] Signin somente os usuario com a role Admin podem criar uma novo usuario;
- [x] Ao criar um usuario a senha deve ser salva encryptada no banco.
