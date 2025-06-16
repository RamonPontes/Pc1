using System.Collections.Generic;
using System.Linq;
using EFCSharpCliente.Models;

namespace EFCSharpCliente.Db
{
    public class DbCliente {
        public void Insere(Cliente cliente) {
            var context = new MyDbContext();        
            context.cliente.Add(cliente);
            context.SaveChanges();
        }

        public void Atualiza(Cliente cliente) {
            var context = new MyDbContext();        
            context.cliente.Update(cliente);
            context.SaveChanges();
        }

        public void Exclui(Cliente cliente) {
            var context = new MyDbContext();        
            context.cliente.Remove(cliente);
            context.SaveChanges();
        }

        public Cliente? Localiza(int id) {
            var context = new MyDbContext();        
            return context.cliente.Where(m => m.Id == id).FirstOrDefault();
        }

        public List<Cliente> Pesquisa() {
            var context = new MyDbContext();        
            return [..context.cliente];
        }
    }
}