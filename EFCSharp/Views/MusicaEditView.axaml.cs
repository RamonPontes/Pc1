using Avalonia.Controls;
using EFCSharp.Models;
using EFCSharp.ViewModels;
namespace EFCSharp.Views;
public partial class MusicaEditView : Window
{
    public MusicaEditView(Musica musica, MainWindowViewModel main)
    {
        InitializeComponent();
        DataContext = new MusicaEditViewModel(musica, main);
    }
}