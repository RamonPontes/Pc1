using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CrudProduto.Bd;
using CrudProduto.Models;
using CrudProduto.Views;

namespace CrudProduto.ViewModels;

public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    ObservableCollection<Produto> produtos = new();
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
        BdProduto bdProduto = new();
        List<Produto> lista = bdProduto.Pesquisa("");
        Produtos.Clear();
        foreach (Produto p in lista)
        {
            Produtos.Add(p);
        }
    }

    public void Novo()
    {
        produtoEditView = new ProdutoEditView(new Produto(), this);
        produtoEditView.Show();
        AtualizaGrid();
    }

    public void Altera()
    {
        if (ProdutoAtual.Id != 0)
        {
            produtoEditView = new ProdutoEditView(ProdutoAtual, this);
            produtoEditView.Show();
        }
    }

    public void Exclui()
    {
        if (ProdutoAtual.Id != 0)
        {
            BdProduto bdProduto = new BdProduto();
            bdProduto.Exclui(ProdutoAtual.Id);
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
