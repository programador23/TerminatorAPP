using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminatorsModel.DTO;

namespace TerminatorsApp
{
    public partial class Program
    {

        public static int GetAnioDestino()
        {
            int anioDestino = -1;
            do
            {
                Console.WriteLine("ingresar anio de destino");
                if (!int.TryParse(Console.ReadLine().Trim(), out anioDestino))
                {
                    Console.WriteLine("el anio de destino debe ser numerico");
                    anioDestino = -1;


                }
                else if (anioDestino < 1984 || anioDestino > 3000)
                {
                    Console.WriteLine("el anio esta afuera de los rangos permitidos");
                    anioDestino = -1;
                }

            } while (anioDestino < 1984 || anioDestino > 3000);
            return anioDestino;
        }

        public static Tipo GetTipo()
        {

            string resp;
            Tipo tipo = Tipo.T1;
            do
            {
                Console.WriteLine("Seleccione tipo");
                Console.WriteLine("1. T-1,2.T-800,3.T-1000,4.T-3000");
                resp = Console.ReadLine().Trim();
                switch (resp)
                {
                    case "1":
                        tipo = Tipo.T1;
                        break;
                    case "2":
                        tipo = Tipo.T800;
                        break;
                    case "3":
                        tipo = Tipo.T1000;
                        break;
                    case "4":
                        tipo = Tipo.T3000;
                        break;
                    default:
                        Console.WriteLine("tipo incorrecto, reingrese");
                        resp = string.Empty;
                        break;
                }

            } while (resp == string.Empty);
            return tipo;
        }
    }
}
