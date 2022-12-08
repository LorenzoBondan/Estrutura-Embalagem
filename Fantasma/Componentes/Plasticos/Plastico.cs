
namespace Fantasma.Componentes.Plasticos
{
    class Plastico : Componente
    {
        public double Gramatura { get; set; }
        public bool Superior { get; set; }
        
        // calculo da quantidade
        public double PlasticoAMais { get; set; }
        public double MaiorMedida { get; set; }
        public int LarguraPlastico { get; set; }

        public Plastico() { }


        public Plastico(string codigo, string descricao, double gramatura, bool superior, int larguraplastico, double plasticoamais, double maiormedida)
        {
            Codigo = codigo;
            Descricao = descricao;
            Gramatura = gramatura;
            Superior = superior;

            // calculo da quantidade 
            LarguraPlastico = larguraplastico;
            PlasticoAMais = plasticoamais;
            MaiorMedida = maiormedida;
        }

        public override double CalcularQuantidade()
        {
            if (Superior == true)
            {
                double quant = ((double)(MaiorMedida) + (double)PlasticoAMais) / 1000 * ((double)LarguraPlastico / 1000) * (double)Gramatura;
                return quant;
            }
            else
            {
                double quant = ((double)MaiorMedida /1000) * ((double)LarguraPlastico / 1000) * (double)Gramatura;
                return quant;
            }
           
        }
    }
}
