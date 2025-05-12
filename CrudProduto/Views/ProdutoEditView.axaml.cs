using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CrudProduto.Models;
using CrudProduto.ViewModels;

namespace CrudProduto.Views;

public partial class ProdutoEditView : Window
{
    public ProdutoEditView(Produto produto, MainWindowViewModel main)
    {
        InitializeComponent();
        DataContext = new ProdutoEditView(produto, main);
    }
}