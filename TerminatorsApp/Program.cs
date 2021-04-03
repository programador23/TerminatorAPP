using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminatorsModel.DAL;
using TerminatorsModel.DTO;

namespace TerminatorsApp
{
    public partial class Program
    {


        static TerminatorsDAL dal = new TerminatorsDAL();
        static void IngresarTerminator()
        {
            string nroSerie, objetivo;
            int prioridad, anioDestino;
            Tipo tipo = Tipo.T1;

            do
            {
                Console.WriteLine("Ingrese nro de serie");
                nroSerie = Console.ReadLine().Trim();
                if(nroSerie.Length != 7)
                {
                    Console.WriteLine("El nro de serie debe ser de largo 7");
                    nroSerie = string.Empty;
                }else if(dal.FindByNroSerie(nroSerie) != null)
                {
                    Console.WriteLine("El terminator ya existe");
                    nroSerie = string.Empty;
                }
            } while (nroSerie == string.Empty);

            tipo = GetTipo();
            do
            {
                Console.WriteLine("Ingrese objetivo");
                objetivo = Console.ReadLine().Trim();
            } while (objetivo == string.Empty);

            if (objetivo.ToLower() == "sarah connor")
            {
                prioridad = 999;
            }else
            {
                do
                {
                    Console.WriteLine("ingresar prioridad");
                    string priorText = Console.ReadLine().Trim();
                    if (!Int32.TryParse(priorText, out prioridad))
                    {
                        prioridad = 1;
                        Console.WriteLine("prioridad incorrecta");
                    }

                } while (prioridad < 0 || prioridad > 999);

            }
            anioDestino = GetAnioDestino();

            Terminator t = new Terminator()
            {
                NroSerie = nroSerie,
                Objetivo = objetivo,
                AnioDestino = anioDestino,
                Tipo = tipo,
                Prioridad = prioridad
            };
            dal.save(t);
        }
        static void MostrarTerminators()
        {
            List<Terminator> terminators = dal.GetAll();
            terminators.ForEach(Console.WriteLine);
        }
        static void BuscarTerminators()
        {
            Tipo tipo = GetTipo();
            int anio = GetAnioDestino();
            List<Terminator> terminators = dal.FindByModeloAndAnio(tipo, anio);
            terminators.ForEach(Console.WriteLine);
        }
        static Boolean Menu()
        {


            Console.ForegroundColor = ConsoleColor.Cyan;
            bool continuar = true;
            Console.WriteLine("Bienvenidos a skynet");
            Console.WriteLine("1.ingresar Terminator\n2.Mostrar Terminators\n3.Buscar terminators" +
                "\n0.Salir");
            String opcion = Console.ReadLine().Trim();
            switch(opcion)
            {
                case "1": IngresarTerminator();
                    break;
                case "2": MostrarTerminators();
                    break;
                case "3": BuscarTerminators();
                    break;
                case "0": continuar = false;
                    break;
                default:
                    Console.WriteLine("Use bien el teclado");
                    Console.ReadKey();
                    break;
            }
            return continuar;
        }
        static void Main(string[] args)
        {
            while (Menu()) ;
        }
    }
}
