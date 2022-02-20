using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RatingDL : IRatingDL
    {
        ApartmentBrokerageContext _data;

        public RatingDL(ApartmentBrokerageContext data)
        {
            _data = data;
        }

        public async Task PostRating(Rating rating)
        {
            await _data.Rating.AddAsync(rating);
            await _data.SaveChangesAsync();
        }
    }
}
