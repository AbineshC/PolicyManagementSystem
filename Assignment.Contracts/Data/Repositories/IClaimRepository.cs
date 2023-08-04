using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Contracts.Data.Repositories
{
    public interface IClaimRepository<T>
    {
            Task<IEnumerable<T>> GetAll();
            Task<T> Get(int id);
            Task<int> Add(T entity);
            Task<int> Update(T entity);
            Task<int> Delete(int id);
            int Count();
        
    }
}
