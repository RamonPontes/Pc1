namespace BdCSharp.Models {
    public class Pessoa {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }

        public Pessoa(string nome, string cpf) {
            Nome = nome;
            Cpf = cpf;
        }

        public Pessoa() { }
    }
}