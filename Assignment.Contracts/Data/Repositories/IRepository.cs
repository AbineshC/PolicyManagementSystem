namespace Assignment.Contracts.Data.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        //IEnumerable<T> GetAll();
        //Task<T> Get(int id);
        //Task<int> Add(T entity);
        //Task<int> Update(T entity);
        //Task<int> Delete(int id);
        int Count();
    }
}