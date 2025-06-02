using System.ComponentModel;
using System.Runtime.CompilerServices;
using CrudProduto.Bd;
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
            BdProduto bdProduto = new();

            if (ProdutoAtual.Id == 0)
            {
                bdProduto.Insere(ProdutoAtual);
            }
            else
            {
                bdProduto.Atualiza(ProdutoAtual);
            }

            main.AtualizaGrid();
            main.produtoEditView.Close();
        }
    }
}
