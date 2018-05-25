using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimer.Services.Repository
{
    public interface IEntityRepository<T>
    {
        void Create(T t);

        bool Edit(T t);
        bool Delete(int? id);
        
        T GetById(int? id);
        IEnumerable<T> GetAll();
    }
}
