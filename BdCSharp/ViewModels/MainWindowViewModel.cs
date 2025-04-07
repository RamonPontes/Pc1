using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BdCSharp.Bd;
using BdCSharp.Models;
using BdCSharp.Views;

namespace BdCSharp.ViewModels;

public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    ObservableCollection<Pessoa> pessoas = [];
    Pessoa pessoaAtual = new();
    public PessoaEditView pessoaEditView { get; set; }
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
        BdPessoa bdp = new();
        List<Pessoa> lista = bdp.Pesquisa("");
        Pessoas.Clear();
        foreach (Pessoa p in lista)
        {
            Pessoas.Add(p);
        }
    }
    public void Novo()
    {
        pessoaEditView = new(new(), this);
        pessoaEditView.Show();
        AtualizaGrid();
    }
    public void Altera()
    {
        if (PessoaAtual.Id != 0)
        {
            pessoaEditView = new(PessoaAtual, this);
            pessoaEditView.Show();
        }
    }
    public void Exclui()
    {
        if (PessoaAtual.Id != 0)
        {
            BdPessoa bdPessoa = new BdPessoa();
            bdPessoa.Exclui(PessoaAtual.Id);
            AtualizaGrid();
        }
    }
    public void Sair()
    {
        Environment.Exit(0);
    }
    public ObservableCollection<Pessoa> Pessoas
    {
        get
        {
            return pessoas;
        }
        set
        {
            pessoas = value;
            OnPropertyChanged();
        }
    }
}