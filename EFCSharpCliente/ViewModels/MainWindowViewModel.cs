using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EFCSharpCliente.Db;
using EFCSharpCliente.Models;
using EFCSharpCliente.Views;
using MsBox.Avalonia;
namespace EFCSharpCliente.ViewModels;
public class MainWindowViewModel : INotifyPropertyChanged
{
    ObservableCollection<Cliente> clientes = [];
    Cliente clienteAtual = new();
    public ClienteEditView? ClienteEditView { get; set; }
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
    public ObservableCollection<Cliente> Clientes
    {
        get
        {
            return clientes;
        }
        set
        {
            clientes = value;
            OnPropertyChanged();
        }
    }
    public MainWindowViewModel()
    {
        AtualizaGrid();
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public void AtualizaGrid()
    {
        DbCliente dbCliente = new();
        List<Cliente> lista = dbCliente.Pesquisa();
        Clientes.Clear();
        foreach (Cliente m in lista)
        {
            Clientes.Add(m);
        }
    }
    public void Novo()
    {
        ClienteEditView = new(new(), this);
        ClienteEditView.Show();
        AtualizaGrid();
    }
    public void Altera()
    {
        if (ClienteAtual != null && ClienteAtual.Id != 0)
        {
            ClienteEditView = new(ClienteAtual, this);
            ClienteEditView.Show();
        }
        else
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Erro",
            "Nenhuma linha selecionada",
            MsBox.Avalonia.Enums.ButtonEnum.Ok
            );
            var result = box.ShowAsync();
        }
    }
    public void Exclui()
    {
        if (ClienteAtual != null && ClienteAtual.Id != 0)
        {
            DbCliente dbCliente = new();
            dbCliente.Exclui(ClienteAtual);
            AtualizaGrid();
        }
        else
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Erro",
            "Nenhuma linha selecionada",
            MsBox.Avalonia.Enums.ButtonEnum.Ok
            );
            var result = box.ShowAsync();
        }
    }
    public void Sair()
    {
        Environment.Exit(0);
    }
}