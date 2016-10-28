using System.Collections.Generic;
namespace CST465Lab4_StephanieVetter
{
    public interface IDataEntityRepository<T> where T : IDataEntity
    {
        T Get(int id);
        void Save(T entity);
        List<T> GetList();
    }
}