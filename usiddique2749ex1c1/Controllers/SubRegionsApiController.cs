using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using usiddique2749ex1c1.Data;
using usiddique2749ex1c1.Models;

namespace usiddique2749ex1c1.Controllers
{
    [Produces("application/json")]
    [Route("api/SubRegionsApi")]
    public class SubRegionsApiController : Controller
    {
        private readonly WideWorldContext _context;

        public SubRegionsApiController(WideWorldContext context)
        {
            _context = context;
        }

        // GET: api/SubRegionsApi
        //[HttpGet]
        // public IEnumerable<string> GetRegions()
        // {
        //     List<string> stringList = new List<string>();
        //     stringList = _context.Countries.Select(c => c.Region).Distinct().OrderBy(r => 1).ToList();
        //     return stringList;
        // }

        // GET: api/SubRegionsApi
        [HttpGet]
        public IEnumerable<SubRegions> GetSubRegions()
        {
            List<string> stringList = new List<string>();
            stringList = _context.Countries.Select(c => c.Subregion).Distinct().OrderBy(r => 1).ToList();
            List<SubRegions> subregionList = new List<SubRegions>();
            foreach (string s in stringList)
            {

                SubRegions r = new SubRegions();
                r.SubRegionName = s;
                subregionList.Add(r);
            }
            return subregionList;
        }

        // GET: api/SubregionsApi/Americas
        [HttpGet("{region}")]
        public async Task<IActionResult> GetSubRegions([FromRoute] string region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<string> stringList = new List<string>();
            stringList = await _context.Countries.Where(r => r.Region == region).Select(c => c.Subregion).Distinct().OrderBy(r => 1).ToListAsync();
            List<SubRegions> subregionList = new List<SubRegions>();
            foreach (string s in stringList)
            {

                SubRegions r = new SubRegions();
                r.SubRegionName = s;
                subregionList.Add(r);
            }

            if (subregionList == null)
            {
                return NotFound();
            }

            return Ok(subregionList);
        }




        //    private bool CountriesExists(int id)
        //    {
        //        return _context.Countries.Any(e => e.CountryId == id);
        //    }
    }
}
