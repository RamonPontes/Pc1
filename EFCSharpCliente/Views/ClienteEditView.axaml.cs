using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using EFCSharpCliente.Models;
using EFCSharpCliente.ViewModels;

namespace EFCSharpCliente.Views;

public partial class ClienteEditView : Window
{
    public ClienteEditView(Cliente cliente, MainWindowViewModel main)
    {
        InitializeComponent();
        DataContext = new ClienteEditViewModel(cliente, main);
    }
}