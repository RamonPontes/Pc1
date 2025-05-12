using System.ComponentModel;
using System.Runtime.CompilerServices;
using CrudProduto.Db;
using CrudProduto.Models;

namespace CrudProduto.ViewModels
{
    public class ProdutoEditViewModel : ViewModelBase, INotifyPropertyChanged
    {
        Produto produtoAtual = new();
        MainWindowViewModel main;
        public Produto ProdutoAtual
        {
            get
            {
                return produtoAtual;
            }
            set
            {
                produtoAtual = value;
                OnPropertyChanged();
            }
        }

        public ProdutoEditViewModel(Produto produto, MainWindowViewModel main)
        {
            ProdutoAtual = produto;
            this.main = main;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Salva()
        {
            DbProduto dbProduto = new();
            if (ProdutoAtual.Id == 0)
            {
                dbProduto.Insere(ProdutoAtual);
            }
            else
            {
                dbProduto.Atualiza(ProdutoAtual);
            }
            main.AtualizaGrid();
            main.produtoEditView.Close();
        }
    }
}