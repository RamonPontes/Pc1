using System.ComponentModel;
using System.Runtime.CompilerServices;
using CalculadoraAvalonia.Models;

namespace CalculadoraAvalonia.ViewModels;

public partial class MainWindowViewModel : INotifyPropertyChanged {
    private Calculadora calculadora = new();
    public float Numero1 { get; set;}
    public float Numero2 { get; set;}
    public float Resultado { get; set; }
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string ? propertyName = null) {
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Soma() {
        calculadora.Numero1 = Numero1;
        calculadora.Numero2 = Numero2;

        calculadora.Soma();

        Resultado = calculadora.Resultado;

        OnPropertyChanged(nameof(Resultado));
    }
}   