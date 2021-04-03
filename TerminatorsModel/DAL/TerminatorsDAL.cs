using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminatorsModel.DTO;

namespace TerminatorsModel.DAL
{
   public class TerminatorsDAL
    {
        private static List<Terminator> terminators = new List<Terminator>();

        public void save(Terminator t)
        {
            terminators.Add(t);
        }

        public List<Terminator> GetAll()
        {
            return terminators;
        }

        public List<Terminator> FindByModeloAndAnio(Tipo tipo, int anio)
        {
            return terminators.FindAll(t => t.Tipo == tipo && t.AnioDestino == anio);
        }

        public Terminator FindByNroSerie(string nroSerie)
        {

            return terminators.Find(t => t.NroSerie == nroSerie);
        }

        public void Delete(Terminator t)
        {
            terminators.Remove(t);
        }

    }
}
