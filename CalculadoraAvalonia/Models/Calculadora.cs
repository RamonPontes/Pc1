namespace CalculadoraAvalonia.Models
{
    public class Calculadora
    {
        public float Numero1 { get; set; }
        public float Numero2 { get; set; }
        public float Resultado { get; set; }

        public void Soma()
        {
            Resultado = Numero1 + Numero2;
        }
        public void Subtrai()
        {
            Resultado = Numero1 - Numero2;
        }
        public void Multiplica()
        {
            Resultado = Numero1 * Numero2;
        }
        public void Divide()
        {
            Resultado = Numero1 / Numero2;
        }
    }
}