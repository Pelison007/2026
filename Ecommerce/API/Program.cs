//POSTMAN
//INSONMIA
//REST CLIENT - Extensão do VSCODE

//TERMINAL
//1 - Criar solução
//2 - Entrar na pasta da solução
//3 - Criar o projeto
//4 - Vincular o projeto para a solução


using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Registrar o Serviço de banco de dados
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

List<Produto> produtos = new List<Produto>();

//FUNCIONALIDADES - EndPoint
//Requisições
// - Método HTTP
// - URL

//Resposta
// - Dado/Informação/Mensagem
// - Código de status HTTP

//GET: http://localhost:5195/
app.MapGet("/", () => "API do Ecommerce");

//GET: /api/produto/listar
app.MapGet("/api/produto/listar", (
    [FromServices] AppDataContext ctx) =>
{
    if (ctx.TabelaProdutos.Count() == 0)
    {
        return Results.BadRequest("A lista de produtos está vazia!");
    }
    return Results.Ok(ctx.TabelaProdutos.ToList());
});

//POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto? produto,
 [FromServices] AppDataContext ctx) =>
{   
    //Validar se existe algo preenchido no nome do produto
    if (produto is null)
    {
        return Results.BadRequest("Produto não pode ser nulo!");
    }

    // Validar se o nome foi preenchido
    if(produto.Nome == "")
    {
        return Results.BadRequest("O nome do produto não pode ser vazio!");
    }

    //Validar se existe um produto com o mesmo nome do produto
    foreach (Produto produtoCadastrado in ctx.TabelaProdutos.ToList())
    {
        if (produtoCadastrado.Nome == produto.Nome)
        {
            return Results.BadRequest("Já existe um produto cadastrado com esse nome!");
        }
    }
    //produtos.Add(produto);
    ctx.TabelaProdutos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto);
});

//GET: /api/produto/buscar/nome_produto
app.MapGet("/api/produto/buscar/{nome}", ([FromRoute]string nome, [FromServices] AppDataContext ctx) =>
{
    //Expressão lambda
    Produto? produtoEncontrado = ctx.TabelaProdutos.FirstOrDefault(x => x.Nome == nome);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    return Results.Ok(produtoEncontrado);    
});

// 2 - Delete Produto
//DELETE: /api/produto/remover/
app.MapDelete("/api/produto/remover/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) =>
{
    //lambda
    Produto? produtoEncontrado = ctx.TabelaProdutos.FirstOrDefault(x => x.Id == id);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("Produto não Encontrado");
    }
    ctx.TabelaProdutos.Remove(produtoEncontrado);
    ctx.SaveChanges();
    return Results.Ok(produtoEncontrado);
});


// 3 - Alterar Produto
//Alterar: /api/produto/alterar/id_produto
app.MapPut("/api/produto/alterar/{id}", ([FromRoute] string id, [FromBody] Produto produtoAlterado, [FromServices] AppDataContext ctx) =>
{
    //lambda
    Produto? produtoEncontrado = ctx.TabelaProdutos.FirstOrDefault(x => x.Id == id);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("Produto não Encontrado");
    }
    produtoEncontrado.Nome = produtoAlterado.Nome;
    ctx.TabelaProdutos.Update(produtoEncontrado);
    ctx.SaveChanges();
    return Results.Ok(produtoEncontrado);
});

app.Run();

//EXERCÍCIO
// 1 - Pesquisar produto por nome
// 2 - Remoção de um produto
// 3 - Alteração de produto


