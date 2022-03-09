using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CodeTableDL : ICodeTableDL
    {
        ApartmentBrokerageContext data;
        public CodeTableDL(ApartmentBrokerageContext data)
        {
            this.data = data;
        }
        public async Task<List<CodeTable>> GetAll()
        {
            return await data.TableCode.ToListAsync();
        }
    }
}
