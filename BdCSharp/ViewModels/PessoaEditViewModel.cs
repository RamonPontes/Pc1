using System.ComponentModel;
using System.Runtime.CompilerServices;
using BdCSharp.Bd;
using BdCSharp.Models;
namespace BdCSharp.ViewModels
{
    public class PessoaEditViewModel : ViewModelBase, INotifyPropertyChanged
    {
        Pessoa pessoaAtual = new();
        MainWindowViewModel main;
        public Pessoa PessoaAtual
        {
            get
            {
                return pessoaAtual;
            }
            set
            {
                pessoaAtual = value;
                OnPropertyChanged();
            }
        }

        public PessoaEditViewModel(Pessoa pessoa, MainWindowViewModel main)
        {
            PessoaAtual = pessoa;
            this.main = main;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Salva()
        {
            BdPessoa bdPessoa = new();
            if (PessoaAtual.Id == 0)
            {
                bdPessoa.Insere(PessoaAtual);
            }
            else
            {
                bdPessoa.Atualiza(PessoaAtual);
            }
            main.AtualizaGrid();
            main.pessoaEditView.Close();
        }
    }
}