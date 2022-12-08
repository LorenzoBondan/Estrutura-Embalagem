
namespace Fantasma.Componentes
{
    class Componente
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public Componente() { }
        public Componente(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public virtual double CalcularQuantidade()
        {
            return 1;
        }

    }
}
