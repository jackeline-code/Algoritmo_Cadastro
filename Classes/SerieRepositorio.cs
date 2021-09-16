using System.Collections.Generic;
using Cad.Series.Interfaces;

namespace Cad.Series
{
    public class SerieRepositorio : IRepositorio<Serie>//implementa uma interface repositório de séries
    {
        private List<Serie> ListaSerie = new List<Serie>();//Quando instaciar ela, vai ser instanciado uma nova lista
        public void Atualiza(int id, Serie objeto)
        {
            ListaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            ListaSerie[id].Exclui();
        }

        public void Insere(Serie objeto)
        {
            ListaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
           return ListaSerie[id];
        }
    }
}