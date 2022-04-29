using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetCharactersAsync(string SearchTerm = "", int page = 1);
        Task<T> GetCharacterByIdAsync(int Id);
        IEnumerable<T> GetCharacters(string SearchTerm = "", int page = 1);
    }
}
