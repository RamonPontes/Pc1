using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CrudProduto.Db;
using CrudProduto.Models;
using CrudProduto.Views;

namespace CrudProduto.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    ObservableCollection<Produto> produtos = [];
    Produto produtoAtual = new();
    public ProdutoEditView produtoEditView { get; set; }
    public Produto ProdutoAtual
    {
        get
        {
            return produtoAtual;
        }
        set
        {
            produtoAtual = value;
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
        DbProduto bdp = new();
        List<Produto> lista = bdp.Pesquisa("");
        Produtos.Clear();
        foreach (Produto p in lista)
        {
            Produtos.Add(p);
        }
    }
    public void Novo()
    {
        produtoEditView = new(new(), this);
        produtoEditView.Show();
        AtualizaGrid();
    }
    public void Altera()
    {
        if (ProdutoAtual.Id != 0)
        {
            produtoEditView = new(ProdutoAtual, this);
            produtoEditView.Show();
        }
    }
    public void Exclui()
    {
        if (ProdutoAtual.Id != 0)
        {
            DbProduto bdPessoa = new DbProduto();
            bdPessoa.Exclui(ProdutoAtual.Id);
            AtualizaGrid();
        }
    }
    public void Sair()
    {
        Environment.Exit(0);
    }
    public ObservableCollection<Produto> Produtos
    {
        get
        {
            return produtos;
        }
        set
        {
            produtos = value;
            OnPropertyChanged();
        }
    }
}