//POSTMAN
//INSONMIA
//REST CLIENT - Extensão do VSCODE

//TERMINAL
//1 - Criar solução
//2 - Entrar na pasta da solução
//3 - Criar o projeto
//4 - Vincular o projeto para a solução
// Console.Clear();

using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AcessoTotal", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


//Registrar o serviço de banco de dados
builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

List<Produto> produtos = new List<Produto>();

//FUNCIONALIDADES - EndPoints
//Requisições
// - Método HTTP
// - URL
// - Opcional - Corpo/Parâmetros de URL

//Resposta
// - Dado/Informação/Mensagem
// - Código de Status HTTP

//GET: http://localhost:5195/
app.MapGet("/", () => "API do Ecommerce");

//GET: /api/produto/listar
app.MapGet("/api/produto/listar", (
    [FromServices] AppDataContext ctx) =>
{
    if (ctx.Produtos.Count() == 0)
    {
        return Results.BadRequest("A lista de produtos está vazia");
    }
    return Results.Ok(ctx.Produtos.ToList());
});

//POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", 
    ([FromBody] Produto? produto,
    [FromServices] AppDataContext ctx) =>
{
    if (produto is null)
    {
        return Results.BadRequest("O produto não pode ser nulo");
    }

    if (produto.Nome == "")
    {
        return Results.BadRequest("O nome não pode ser vazio");
    }

    //Expressão lambda
    Produto? produtoEncontrado = ctx.Produtos.FirstOrDefault(x => x.Nome == produto.Nome);
    if (produtoEncontrado is not null)
    {
        return Results.BadRequest("Esse produto ja existe!");
    }

    ctx.Produtos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto);
});

//GET: /api/produto/buscar/nome_produto
app.MapGet("/api/produto/buscar/{nome}", 
    ([FromRoute] string nome,
    [FromServices] AppDataContext ctx) =>
{
    //Expressão lambda
    Produto? produtoEncontrado = ctx.Produtos.FirstOrDefault(x => x.Nome == nome);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    return Results.Ok(produtoEncontrado);    
});

//DELETE: /api/produto/remover/id_produto
app.MapDelete("/api/produto/remover/{id}", 
    ([FromRoute] string id,
    [FromServices] AppDataContext ctx) =>
{
    //Expressão lambda
    Produto? produtoEncontrado = ctx.Produtos.Find(id);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    ctx.Produtos.Remove(produtoEncontrado);
    ctx.SaveChanges();
    return Results.Ok(produtoEncontrado);    
});

//DELETE: /api/produto/alterar/id_produto
app.MapPut("/api/produto/alterar/{id}", 
    ([FromRoute] string id, 
    [FromBody] Produto produtoAlterado,
    [FromServices] AppDataContext ctx) =>
{
    //Expressão lambda
    Produto? produtoEncontrado = ctx.Produtos.Find(id);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    
    produtoEncontrado.Nome = produtoAlterado.Nome;
    produtoEncontrado.Valor = produtoAlterado.Valor;
    ctx.Produtos.Update(produtoEncontrado);
    ctx.SaveChanges();
    return Results.Ok(produtoEncontrado);    
});

app.UseCors("AcessoTotal");
app.Run();
