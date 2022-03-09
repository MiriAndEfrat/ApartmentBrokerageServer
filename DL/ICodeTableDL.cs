using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICodeTableDL
    {
        Task<List<CodeTable>> GetAll();
    }
}