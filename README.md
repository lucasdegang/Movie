<h1 align="center">Movie List</h1>

<p align="center"> Desafio Tecnico "MovieList". </p>

---
### **Dependências**
- [Microsoft.EntityFrameworkCore" Version="5.0.10"](https://dotnet.microsoft.com/download/dotnet/5.0)
---
### **Detalhes do projeto**
- .Net Core 5.0
- WebApi
- Swagger
- DB em modo "InMemory" (caso desejado preparado para uso o SqlServer)
- Nível 2 de maturidade de Richardson
- O arquivo de consumo da aplicação deverá ser disponibilizado em: "C:\temp" com a descrição do arquivo "movielist.csv"
### **Detalhes técnicos**
-
### **Executando a Aplicação**
### **Preparativos**
- Verificar sdk compatível ao do projeto.
```
dotnet --list-sdks
```
- Realizar clone do repositório.
### **Backend**
1. Acesse o prompt de comandos.
2. Digite o comando `dotnet restore` para realização do restore do projeto.
3. Digite o comando `dotnet build` para a construção da aplicação.
4. Digite o comando `dotnet watch run --project ./Consumer.MovieList.Api\Consumer.MovieList.Api.csproj`
5. Acessar o swagger pelo caminho: https://localhost:5001/swagger/index.html

---
### **Contato**
https://www.linkedin.com/in/lucas-degang/