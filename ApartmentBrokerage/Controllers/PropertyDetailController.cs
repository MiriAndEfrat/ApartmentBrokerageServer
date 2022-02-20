using BL;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApartmentBrokerage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PropertyDetailController : ControllerBase
    {
        IPropertyDetailBL _propertyDetailBL;
        public PropertyDetailController(IPropertyDetailBL propertyDetailBL)
        {
            _propertyDetailBL = propertyDetailBL;
        }
        // GET: api/<PropertyDetailController>
        [HttpGet("areaId/{id}")]
        public async Task<List<PropertyDetail>> GetByAreaId(int id)
        {
            return await _propertyDetailBL.GetByArea(id);
        }

        // GET api/<PropertyDetailController>/5
        [HttpGet("advertiserId/{id}")]
        public async Task<List<PropertyDetail>> GetByUserId(int id)
        {
            return await _propertyDetailBL.GetByUserId(id);

        }


        // POST api/<PropertyDetailController>
        [HttpPost]
        public async Task Post([FromBody] PropertyDetail propertyDetail)
        {
            await _propertyDetailBL.PostPropertyDetail(propertyDetail);

        }

        // PUT api/<PropertyDetailController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PropertyDetail propertyDetail)
        {
            await _propertyDetailBL.PutPropertyDetail(id, propertyDetail);


        }

        // DELETE api/<PropertyDetailController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _propertyDetailBL.DeletePropertyDetail(id);
        }
    }
}
