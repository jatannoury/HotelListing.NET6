using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;
using AutoMapper;
using HotelListing.API.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // By adding this line we made every endpoint correlated with the countries controller protected by htis flag
    // The authorize flag can be set separately for each standalone endpoint, by moving its location from here to above each reaquired endpoint to be authorized
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(IMapper mapper, ICountriesRepository countriesRepository)
        {
            //_context = context; // dbContext Injection
            this._mapper = mapper; // autoMapper injection
            this._countriesRepository = countriesRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryModel>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryModel>>(countries);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryModel>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetDetails(id); //.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id)

            if (country == null) // id not found
            {
                return NotFound(); //404
            }
            var countryModel = _mapper.Map<CountryModel>(country);
            return Ok(countryModel);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryModel updateCountryModel)
        {
            if (id != updateCountryModel.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            //_context.Entry(updateCountryModel).State = EntityState.Modified; //changes the state of the entity to update before modifying it so that we know that it is not a new record
            var country = await _countriesRepository.GetAsync(id);
            if (country == null) {
                return NotFound();
            }
            _mapper.Map(updateCountryModel, country); 

            try
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await CountryExists(id) == false)
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryModel createCountry)
        {
            // overposting protection and Mapping
            var country = _mapper.Map<Country>(createCountry);

            await _countriesRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await _countriesRepository.DeleteAsync(id);
            //await _countriesRepository.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
