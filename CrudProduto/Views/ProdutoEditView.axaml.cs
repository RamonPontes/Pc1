using Avalonia.Controls;
using CrudProduto.Models;
using CrudProduto.ViewModels;

namespace CrudProduto.Views;

public partial class ProdutoEditView : Window
{
    public ProdutoEditView(Produto produto, MainWindowViewModel main)
    {
        InitializeComponent();
        DataContext = new ProdutoEditViewModel(produto, main);
    }
}
