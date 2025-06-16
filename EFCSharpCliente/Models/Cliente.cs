using System;

namespace EFCSharpCliente.Models
{
    public class Cliente {
        public int Id {get; set;}
        public string Nome {get; set;} = "";
        public string Endereco {get; set;} = "";
        public string Cidade {get; set;} = "";
        public string Uf {get; set;} = "";
        public double Limite {get; set;}
    }
}