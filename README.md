# ASP.NET 7 - WEB API -Blazor - CRUD

This applcation was made with:
- ASP.NET Core 7
- SQL Server 2019
- Blazor WebAssembly App

Required packages in Visual Studio (BlazorCrud_Server Folder):
- Microsoft.EntityFrameworkCore.SqlServer 7.0.3
- Microsoft.EntityFrameworkCore.Tools 7.0.3

Use the following command line to add our database context to our project:
- In Visual Studio, find the "Tools" tab > NuGet Package Manager > Package Manager Console.
- And paste in the console -> Scaffold-DbContext "Server=(local); DataBase=db_blazorwebapicrud_1; Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models