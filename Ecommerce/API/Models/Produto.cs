public class Produto
{

    //Construtor
    // public Produto()
    // {
    //     CriadoEm = DateTime.Now;
    // }

    //C#
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Nome { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;

    //JAVA
    // private string nome;
    // public void setNome(string nome)
    // {
    //     this.nome = nome;
    // }
    // public string getNome()
    // {
    //     return nome;
    // }
}