using System.Collections.Generic;

namespace Cad.Series.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista(); //método que retora uma lista
         T RetornaPorId(int id);//Passo um Id por parametro e ele retorna um T        
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}