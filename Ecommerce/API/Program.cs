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
app.MapGet("/api/produto/listar", () =>
{
    if (produtos.Count == 0)
    {
        return Results.BadRequest("A lista de produtos está vazia!");
    }
    return Results.Ok(produtos);
});

//POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", (Produto? produto) =>
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
    foreach (Produto produtoCadastrado in produtos)
    {
        if (produtoCadastrado.Nome == produto.Nome)
        {
            return Results.BadRequest("Já existe um produto cadastrado com esse nome!");
        }
    }
    produtos.Add(produto);
    return Results.Created("", produto);
});

//GET: /api/produto/buscar/nome_produto
app.MapGet("/api/produto/buscar/{nome}", (string nome) =>
{
    //Expressão lambda
    Produto? produtoEncontrado = produtos.FirstOrDefault(x => x.Nome == nome);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    return Results.Ok(produtoEncontrado);    
});

// 2 - Delete Produto
//DELETE: /api/produto/remover/
app.MapDelete("/api/produto/remover/{id}", (string id) =>
{
    //lambda
    Produto? produtoEncontrado = produtos.FirstOrDefault(x => x.Id == id);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("Produto não Encontrado");
    }
    produtos.Remove(produtoEncontrado);
    return Results.Ok(produtoEncontrado);
});


// 3 - Alterar Produto
//Alterar: /api/produto/alterar/id_produto
app.MapPut("/api/produto/alterar/{id}", ([FromRoute] string id, [FromBody] Produto produtoAlterado) =>
{
    //lambda
    Produto? produtoEncontrado = produtos.FirstOrDefault(x => x.Id == id);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("Produto não Encontrado");
    }
    produtoEncontrado.Nome = produtoAlterado.Nome;
    return Results.Ok(produtoEncontrado);
});

app.Run();

//EXERCÍCIO
// 1 - Pesquisar produto por nome
// 2 - Remoção de um produto
// 3 - Alteração de produto


