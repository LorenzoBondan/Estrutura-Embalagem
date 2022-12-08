
namespace Fantasma.Componentes.Polietileno
{
    class Polietileno : Componente
    {
        public double Medida1 { get; set; }
        public double Medida2 { get; set; }
        
        public Polietileno() { }

        public Polietileno(string codigo, string descricao, double medida1, double medida2) 
        {
            Codigo = codigo;
            Descricao = descricao;
            Medida1 = medida1;
            Medida2 = medida2;
        }

        public override double CalcularQuantidade()
        {
            double qte = ((Medida1/1000) + (Medida2/1000)) * 2 * 0.98; // perímetro - 2%
            return qte;
        }
    }
}
