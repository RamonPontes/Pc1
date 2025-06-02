using System;
using System.Collections.Generic;
using System.Linq;
using EFCSharp.Models;
namespace EFCSharp.Db
{
    public class DbMusica
    {

        public void Insere(Musica musica)
        {
            var context = new MyDbContext();
            context.musica.Add(musica);
            context.SaveChanges();
        }
        public void Atualiza(Musica musica)
        {
            var context = new MyDbContext();
            context.musica.Update(musica);
            context.SaveChanges();
        }
        public void Exclui(Musica musica)
        {
            var context = new MyDbContext();
            context.musica.Remove(musica);
            context.SaveChanges();
        }
        public Musica? Localiza(int id)
        {
            var context = new MyDbContext();
            return context.musica.Where(m => m.Id == id).FirstOrDefault();
        }

        public List<Musica> Pesquisa()
        {
            var context = new MyDbContext();

            return [..context.musica];
        }
    }
}