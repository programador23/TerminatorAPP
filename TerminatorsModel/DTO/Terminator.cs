using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminatorsModel.DTO
{
    public enum Tipo
    {
        T1,T800,T1000,T3000
    }
    public class Terminator
    {
        private string nroSerie;
        private int prioridad;
        private string objetivo;
        private int anioDestino;
        private Tipo tipo;

        public string NroSerie { get => nroSerie; set => nroSerie = value; }
        public int Prioridad { get => prioridad; set => prioridad = value; }
        public string Objetivo { get => objetivo; set => objetivo = value; }
        public int AnioDestino { get => anioDestino; set => anioDestino = value; }
        public Tipo Tipo { get => tipo; set => tipo = value; }

        public override string ToString()
        {
            return nroSerie + " " + tipo + " " + objetivo;
        }
    }
}
