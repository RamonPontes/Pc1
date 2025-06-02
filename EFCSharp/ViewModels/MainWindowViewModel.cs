using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EFCSharp.Db;
using EFCSharp.Models;
using EFCSharp.Views;
using MsBox.Avalonia;
namespace EFCSharp.ViewModels;
public class MainWindowViewModel : INotifyPropertyChanged
{
    ObservableCollection<Musica> musicas = [];
    Musica musicaAtual = new();
    public MusicaEditView? MusicaEditView { get; set; }
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
    public ObservableCollection<Musica> Musicas
    {
        get
        {
            return musicas;
        }
        set
        {
            musicas = value;
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
        DbMusica dbMusica = new();
        List<Musica> lista = dbMusica.Pesquisa();
        Musicas.Clear();
        foreach (Musica m in lista)
        {
            Musicas.Add(m);
        }
    }
    public void Novo()
    {
        MusicaEditView = new(new(), this);
        MusicaEditView.Show();
        AtualizaGrid();
    }
    public void Altera()
    {
        if (MusicaAtual != null && MusicaAtual.Id != 0)
        {
            MusicaEditView = new(MusicaAtual, this);
            MusicaEditView.Show();
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
        if (MusicaAtual != null && MusicaAtual.Id != 0)
        {
            DbMusica dbMusica = new();
            dbMusica.Exclui(MusicaAtual);
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