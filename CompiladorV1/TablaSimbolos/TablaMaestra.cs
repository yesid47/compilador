using CompiladorV1.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorV1.TablaSimbolos
{
    public class TablaMaestra
    {
        public static void SincronizarSimbolo(ComponenteLexico componente)
        {
            if (componente != null)
            {

                //TablaSimbolos.Agregar(componente);
                switch (componente.Tipo)
                {
                    case TipoComponente.SIMBOLO:
                        if (componente.Categoria.Equals(Categoria.VARIABLE))
                        {
                            TablaSimbolos.Agregar(componente);
                        }
                        else
                        {
                            componente.Tipo = TipoComponente.LITERAL;
                            TablaSimbolos.Agregar(componente);
                        }
                        break;
                    case TipoComponente.DUMMY:
                        TablaDummy.Agregar(componente);
                        break;
                    case TipoComponente.LITERAL:
                        TablaLiterales.Agregar(componente);
                        break;
                    case TipoComponente.PALABRA_RESERVADA:
                        TablaLiterales.Agregar(componente);
                        break;

                }
            }
        }
    }
}
