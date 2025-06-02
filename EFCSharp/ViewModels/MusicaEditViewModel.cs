using System.ComponentModel;
using System.Runtime.CompilerServices;
using EFCSharp.Db;
using EFCSharp.Models;
namespace EFCSharp.ViewModels
{
    public class MusicaEditViewModel : INotifyPropertyChanged
    {
        Musica musicaAtual = new();
        MainWindowViewModel main;
        public Musica MusicaAtual
        {
            get
            {
                return musicaAtual;
            }
            set
            {
                musicaAtual = value;
                OnPropertyChanged();
            }
        }
        public MusicaEditViewModel(Musica musica, MainWindowViewModel main)
        {
            MusicaAtual = musica;
            this.main = main;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Salva()
        {
            DbMusica dbMusica = new();

            if (MusicaAtual.Id == 0)
            {
                dbMusica.Insere(MusicaAtual);
            }
            else
            {
                dbMusica.Atualiza(MusicaAtual);
            }
            main.AtualizaGrid();
            main.MusicaEditView?.Close();
        }
    }
}