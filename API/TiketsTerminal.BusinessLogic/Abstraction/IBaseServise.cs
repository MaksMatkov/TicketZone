using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.BusinessLogic.Abstraction
{
    public interface IBaseServise<T> where T : class
    {
        public Task<IEnumerable<T>> GetAsync();
        public Task<T> GetByKeysAsync(params object[] keyValues);
        public void Delete(T item);
        public Task<bool> Delete(int id);
        public Task<T> SaveAsync(T item);
    }
}
