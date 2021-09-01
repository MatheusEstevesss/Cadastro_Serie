using System.Collections.Generic;

namespace cadastro_series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Listar();
        T GetById(int id);
        void Cadastrar(T nova_serie);
        void Deletar(int id);
        void Atualizar(T serie_autalizada, int id);
        int ProximoId();
    }
}