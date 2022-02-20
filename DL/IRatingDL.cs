using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IRatingDL
    {
        public Task PostRating(Rating rating);
    }
}
