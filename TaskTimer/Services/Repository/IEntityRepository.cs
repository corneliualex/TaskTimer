using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimer.Services.Repository
{
    public interface IEntityRepository<T>
    {
        T GetById(int? id);
        IEnumerable<T> GetAll();
        void Update(T t);
        bool Delete(int? id);
    }
}
