using Avalonia.Controls;
using BdCSharp.Models;
using BdCSharp.ViewModels;
namespace BdCSharp.Views;
public partial class PessoaEditView : Window
{
    public PessoaEditView(Pessoa pessoa, MainWindowViewModel main)
    {
        InitializeComponent();
        DataContext = new PessoaEditViewModel(pessoa, main);
    }
}