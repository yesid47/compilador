using CompiladorV1.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorV1.TablaSimbolos
{
    class TablaPalabrasReservadas
    {

		private static Dictionary<String, List<ComponenteLexico>> tabla
		  = new Dictionary<string, List<ComponenteLexico>>();

		private static void inicializar()
		{
			tabla.Add("INT", ComponenteLexico.crear("INT", Categoria.PALABRA_RESERVADA_INT));
			tabla.Add("ON", ComponenteLexico.crear("ON", Categoria.PALABRA_RESERVADA_ON));
			tabla.Add("OFF", ComponenteLexico.crear("OFF", Categoria.PALABRA_RESERVADA_OFF));
		}

		private static List<ComponenteLexico> ObtenerSimbolos(string clave)
		{
			if (!tabla.ContainsKey(clave))
			{
				tabla.Add(clave, new List<ComponenteLexico>());
			}

			return tabla[clave];
		}

		public static void validarSiEsPalabraReservada(ComponenteLexico componente)
		{
			if (componente != null && tabla.ContainsKey(componente.Lexema))
			{
				componente.Tipo = TipoComponente.PALABRA_RESERVADA;
				componente.Categoria = tabla[componente.Lexema].Add(TipoComponente);
			}
		}

		public static void Agregar(ComponenteLexico componente)
		{
			if (componente != null && !componente.Lexema.Equals("") && componente.Tipo.Equals(TipoComponente.LITERAL))
			{
				ObtenerSimbolos(componente.Lexema).Add(componente);
			}
		}

		public static List<ComponenteLexico> ObtenerTodosSimbolos()
		{
			return tabla.Values.SelectMany(componente => componente).ToList();
		}

		public static void Limpiar()
		{
			tabla.Clear();
		}
	}
}
