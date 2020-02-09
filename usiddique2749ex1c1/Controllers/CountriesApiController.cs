﻿using System;
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
    [Route("api/CountriesApi")]
    public class CountriesApiController : Controller
    {
        private readonly WideWorldContext _context;

        public CountriesApiController(WideWorldContext context)
        {
            _context = context;
        }

        // GET: api/CountriesApi
        [HttpGet]
        public IEnumerable<Countries> GetCountries()
        {
            return _context.Countries;
        }

        //// GET: api/CountriesApi
        //[HttpGet]
        //public async Task<IActionResult> GetCountries([FromQuery] string subregion)
        //{
        //    //return _context.Countries;
        //    //var countries = await _context.Countries.Where(c => c.Subregion == subregion).ToListAsync();
        //    //return Ok(countries);
        //    List<Countries> countries = new List<Countries>();
        //    if (String.IsNullOrEmpty(subregion))
        //        countries = await _context.Countries.ToListAsync();
        //    else
        //        countries = await _context.Countries.Where(c => c.Subregion == subregion).ToListAsync();

        //    //return Ok(new { d = countries });
        //    return Ok(new { countries = countries });   // Wrap array in object to prevent JSON hijacking
        //}

        // GET: api/CountriesApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var countries = await _context.Countries.SingleOrDefaultAsync(m => m.CountryId == id);

            if (countries == null)
            {
                return NotFound();
            }

            return Ok(countries);
        }

        // PUT: api/CountriesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountries([FromRoute] int id, [FromBody] Countries countries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != countries.CountryId)
            {
                return BadRequest();
            }

            _context.Entry(countries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CountriesApi
        [HttpPost]
        public async Task<IActionResult> PostCountries([FromBody] Countries countries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Countries.Add(countries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountries", new { id = countries.CountryId }, countries);
        }

        // DELETE: api/CountriesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountries([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var countries = await _context.Countries.SingleOrDefaultAsync(m => m.CountryId == id);
            if (countries == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(countries);
            await _context.SaveChangesAsync();

            return Ok(countries);
        }

        private bool CountriesExists(int id)
        {
            return _context.Countries.Any(e => e.CountryId == id);
        }
    }
}