using System.ComponentModel;
using System.Runtime.CompilerServices;
using EFCSharpCliente.Db;
using EFCSharpCliente.Models;

namespace EFCSharpCliente.ViewModels
{
    public class ClienteEditViewModel : INotifyPropertyChanged
    {
        Cliente clienteAtual = new();
        MainWindowViewModel main;
        public Cliente ClienteAtual
        {
            get
            {
                return clienteAtual;
            }
            set
            {
                clienteAtual = value;
                OnPropertyChanged();
            }
        }
        public ClienteEditViewModel(Cliente cliente, MainWindowViewModel main)
        {
            ClienteAtual = cliente;
            this.main = main;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Salva()
        {
            DbCliente dbCliente = new();

            if (ClienteAtual.Id == 0)
            {
                dbCliente.Insere(ClienteAtual);
            }
            else
            {
                dbCliente.Atualiza(ClienteAtual);
            }
            main.AtualizaGrid();
            main.ClienteEditView?.Close();
        }
    }
}