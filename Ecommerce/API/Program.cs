//POSTMAN
//INSONMIA
//REST CLIENT - Extensão do VSCODE

//TERMINAL
//1 - Criar solução
//2 - Entrar na pasta da solução
//3 - Criar o projeto
//4 - Vincular o projeto para a solução

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
    bool nomeExiste = false;

    // Validar se o nome foi preenchido
    if (string.IsNullOrWhiteSpace(produto.Nome))
    {
        return Results.BadRequest("Nome do produto deve ser preenchido!");
    }

    //Validar se existe um produto com o mesmo nome do produto
    foreach (Produto p in produtos)
    {
        if (produto.Nome == p.Nome)
        {
            nomeExiste = true;
            break;
        }
    }

    if (nomeExiste)
    {
        return Results.BadRequest("Já existe um produto com esse nome!");
    }
    else
    {
        produtos.Add(produto);
        return Results.Created("", produto);   
    }
});

app.Run();

//EXERCÍCIO
// 1 - Pesquisar produto por nome
// 2 - Remoção de um produto
// 3 - Alteração de produto


