using System.Collections.Generic;
using cadastro_series.Interfaces;

namespace cadastro_series.Classes
{
    public class SerieRepository : IRepository<Series>
    {
        private List<Series> _listaSeries = new List<Series>();
        public void Atualizar(Series serie_autalizada, int id)
        {
            _listaSeries[id] = serie_autalizada;
        }

        public void Cadastrar(Series nova_serie)
        {
            _listaSeries.Add(nova_serie);
        }

        public void Deletar(int id)
        {
            _listaSeries[id].Excluir();
        }

        public Series GetById(int id)
        {
            return _listaSeries[id];
        }

        public List<Series> Listar()
        {
            return _listaSeries;
        }

        public int ProximoId()
        {
            return _listaSeries.Count;
        }
    }
}