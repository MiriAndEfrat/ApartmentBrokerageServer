using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RatingBL: IRatingBL
    {
        IRatingDL _ratingDL;
        public RatingBL(IRatingDL ratingDL)
        {
            _ratingDL = ratingDL;
        }
        public async Task PostRating(Rating rating)
        {
            await _ratingDL.PostRating(rating);
        }
    }
}
