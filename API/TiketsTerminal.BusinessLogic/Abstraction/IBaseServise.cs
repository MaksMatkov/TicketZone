using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Abstraction;

namespace TiketsTerminal.BusinessLogic.Abstraction
{
    public interface IBaseServise<T> where T : IEntity
    {
        public Task<IEnumerable<T>> GetAsync();
        public Task<T> GetByKeysAsync(params object[] keyValues);
        public Task<bool> Delete(T item);
        public Task<bool> Delete(int id);
        public Task<T> SaveAsync(T item);
        public Task<T> UpdateAsync(T newValue, params object[] keyValues);
    }
}
