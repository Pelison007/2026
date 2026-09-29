using Microsoft.EntityFrameworkCore;

//CONFIGURAÇÃO COM BANCO DE DADOS
//1º Instalar as Bibliotecas
//2º Criar a classe de dados
//3º Criar a herança com a biblioteca
//4º Indicar as classes de modelo que vão virar
//  Tabelas no Banco de dados
//5º Sobrescrever o método de configuração, com
//  o banco utilizado e a string de conexão
public class AppDataContext : DbContext
{
    public DbSet<Produto> TabelaProdutos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Ecommerce.db");
    }
}