using Avalonia;
using Avalonia.Controls;
using CrudProduto.ViewModels;
using Avalonia.Markup.Xaml;
using CrudProduto.Models;
using CrudProduto.ViewModels;

namespace BdCSharp.Views;

public partial class ProdutoEditView : Window
{
    public ProdutoEditView(Produto produto, MainWindowViewModel main)
    {
        InitializeComponent();
        DataContext = new ProdutoEditViewModel(produto, main);
    }
}