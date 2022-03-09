using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CodeTableBL : ICodeTableBL
    {
        ICodeTableDL _codeTableDL;
        public CodeTableBL(ICodeTableDL codeTableDL)
        {
            _codeTableDL = codeTableDL;
        }
        public async Task<List<CodeTable>> GetAll()
        {
            return await _codeTableDL.GetAll();
        }
    }
}
