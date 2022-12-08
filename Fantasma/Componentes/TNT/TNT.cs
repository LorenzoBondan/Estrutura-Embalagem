
namespace Fantasma.Componentes.TNT
{
    class TNT : Componente
    {
        public bool UmaFace { get; set; }

        // calculo da quantidade

        public double Medida1 { get; set; }
        public double Medida2 { get; set; }
        public double Medida3 { get; set; }

        public TNT() { }

        public TNT(string codigo, string descricao, bool umaFace, double medida1, double medida2, double medida3)
        {
            Codigo = codigo;
            Descricao = descricao;
            UmaFace = umaFace;

            // calculo da quantidade
            Medida1 = medida1;
            Medida2 = medida2;
            Medida3 = medida3;

        }

        public override double CalcularQuantidade()
        {
            double quantidade = 0;
            double complemento = Medida3 * 2;

            if (UmaFace == true)
            {
                quantidade = ((Medida1+complemento)/1000) * ((Medida2+complemento)/1000);
            }
            else
            {
                quantidade = ((Medida1/1000)*(Medida2/1000)*2) +  ((Medida1/1000)*2*(Medida3/1000)) + ((Medida2/1000)*2*(Medida3/1000));
            }
            return quantidade;
        }
    }
}
