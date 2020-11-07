using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assigment_No3._0.Data;
using Assigment_No3._0.Model;
using Microsoft.AspNetCore.Mvc;

namespace Assigment_No3._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IAdultService AdultService;

        public AdultController(IAdultService adultService)
        {
            AdultService = adultService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            try
            {
                IList<Adult> todos = await AdultService.GetAdultsAsync();
                return Ok(todos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Adult added = await AdultService.AddAdultsAsync(adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id)
        {
            try
            {
                await AdultService.RemoveAdultsAsync(id);
                return Ok(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateAdult([FromRoute] int id, [FromBody] Adult adultus)
        {
            try
            {
                foreach (var adult in AdultService.GetAdultsAsync().Result)
                {
                    if (adult.Id == id)
                    {
                        adultus.Id = id;
                        await AdultService.UpdateAdultsAsync(adultus);
                    }
                }
                return Ok(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}