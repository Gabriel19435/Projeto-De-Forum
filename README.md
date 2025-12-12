Projeto De Forum (ASP.NET Core 8 + EF Core 9)

📌 Sobre o Projeto

Este e meu primeiro projeto desenvolvido com ASP.NET Core 8, ele utiliza Entity Framework Core 9, SQL Server, e arquitetura organizada com injeção de dependência, services, repositories e migrations.
O Projeto permite gerenciamento de usuários, posts e imagens,


🛠️ Tecnologias Utilizadas

ASP.NET Core 8

Entity Framework Core 9

SQL Server


📂 Estrutura da Solução
Blog_Projeto/

 ├── Controllers/
 
 ├── Data/
 
 │    └── AppDbContext.cs
 
 ├── Migrations/
 
 ├── Models/
 
 ├── Repositories/
 
 ├── Services/
 
 ├── wwwroot/
 
 │    ├── css/
 
 │    ├── js/
 
 │    ├── PostImg/
 
 │      └── ProfileImages/UserPic/
 
 │      └── ProfileImages/UserPic/
 
 ├── Program.cs
 
 ├── Blog_Projeto.csproj
 
 └── Blog_Projeto.sln
 

⚙️ Configuração do Ambiente

1️⃣ Configurar string de conexão

No arquivo appsettings.json adicione sua connection string:

"ConnectionStrings": {

  "DefaultConnection": "Server=SEU_SERVIDOR;Database=BlogProject;Trusted_Connection=True;TrustServerCertificate=True"
  
}


🗄️ Migrations

✔️ Criar migration

dotnet ef migrations add InitialCreate

✔️ Update do banco

dotnet ef database update


**As migrations já estão incluídas no repositório para facilitar a reprodução do ambiente.**

▶️ Como executar o projeto

1. Restaurar dependências

2. dotnet restore

3. Rodar o projeto

4. dotnet run


🖼️ Pastas de Imagens dos Posts - Usuarios

wwwroot/PostImg/

wwwroot/ProfileImages/UserPic/

Essas pastas já estão incluídas no projeto.


🤝 Contribuindo

Pull requests são bem-vindos!

Para grandes alterações, abra uma issue antes e discuta o que deseja mudar.
