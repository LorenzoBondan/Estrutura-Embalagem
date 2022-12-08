
namespace Fantasma.Componentes.Cantoneiras
{
    class Cantoneira : Componente
    {
        // codigo e descricao
        public double Quantidade { get; set; }

        public Cantoneira(string codigo, string descricao, double quantidade)
        {
            Codigo = codigo;
            Descricao = descricao;
            Quantidade = quantidade;
        }

        // qte fixa ex: [1,2,3,4]
        public override double CalcularQuantidade()
        {
            return Quantidade;
        }

    }
}
