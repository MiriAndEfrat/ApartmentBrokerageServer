using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRatingBL
    {
        public Task PostRating(Rating rating);
    }
}
