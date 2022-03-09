using BL;
using Entity;
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
    public class CodeTableController : ControllerBase
    {
        ICodeTableBL _codeTableBL;
        public CodeTableController(ICodeTableBL codeTableBL)
        {
            _codeTableBL = codeTableBL;
        }
        // GET: api/<CodeTableController>
        [HttpGet]
        public async Task<List<CodeTable>> Get()
        {
            return await _codeTableBL.GetAll();
         
        }
        

        //// GET api/<CodeTableController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<CodeTableController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CodeTableController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CodeTableController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
