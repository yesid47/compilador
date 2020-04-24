using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorV1.Transversal
{
    public class ComponenteLexico
    {
        public Categoria Categoria { get; internal set; }
        public String Lexema { get; set; }
        public Categoria categoria { get; set; }
        public int NumeroLinea { get; set; }
        public int PosicionInicial { get; set; }
        public int PosicionFinal { get; set; }

        public TipoComponente Tipo { get; set; }

        public static ComponenteLexico crear(String lexema, Categoria categoria, int numeroLinea, int posicionInicial, int posicionFinal)
        {
            ComponenteLexico retorno = new ComponenteLexico();
            retorno.Lexema = lexema;
            retorno.Categoria = categoria;
            retorno.NumeroLinea = numeroLinea;
            retorno.PosicionInicial = posicionInicial;
            retorno.PosicionFinal = posicionFinal;
            return retorno;

        }

        public static ComponenteLexico crear(String lexema, Categoria categoria)
        {
            ComponenteLexico retorno = new ComponenteLexico();
            retorno.Lexema = lexema;
            retorno.Categoria = categoria;
            retorno.NumeroLinea = 0;
            retorno.PosicionInicial = 0;
            retorno.PosicionFinal = 0;
            return retorno;

        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("Tipo Componente: " + Tipo.ToString() + "\n");
            retorno.Append("Categoría: " + Categoria + "\n");
            retorno.Append("Lexema: " + Lexema +"\n");
            retorno.Append("Numero linea: " + NumeroLinea + "\n");
            retorno.Append("Posición inicial: " + PosicionInicial + "\n");
            retorno.Append("Posición final: " + PosicionFinal + "\n");

            return base.ToString();
        }


    }
}
