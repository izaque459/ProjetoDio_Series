using System.Collections.Generic;

namespace DIO_Series.Interface
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaPorID(int id);
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T entidade);

         int ProximoId();

    }
}