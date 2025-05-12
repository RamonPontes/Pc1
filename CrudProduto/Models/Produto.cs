namespace CrudProduto.Models {
    public class Produto {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? Valor { get; set; }

        public Produto(string nome, int valor) {
            Nome = nome;
            Valor = valor;
        }

        public Produto() { }
    }
}