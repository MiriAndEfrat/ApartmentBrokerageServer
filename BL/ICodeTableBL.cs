using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICodeTableBL
    {
        Task<List<CodeTable>> GetAll();
    }
}