namespace CrudProduto.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public string? Marca { get; set; }
        public int Quantidade { get; set; }

        public Produto(string descricao, string marca, int quantidade)
        {
            Descricao = descricao;
            Marca = marca;
            Quantidade = quantidade;
        }

        public Produto() { }
    }
}
