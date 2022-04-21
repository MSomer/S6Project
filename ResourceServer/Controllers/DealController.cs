using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceServer.Model.Deal;
using ResourceServer.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace ResourceServer.Controllers
{
    [Route("api/[controller]")]
    //TODO deze naam veranderen
    //[Authorize("dataEventRecordsPolicy")]
    //[Authorize(Roles = "admin")]
    [ApiController]
    public class DealController : ControllerBase
    {
        private readonly IDealRepository dealRepository;
        public DealController(IDealRepository _dealRepository)
        {
            dealRepository = _dealRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDeals()
        {
            try
            {
                var deals = await dealRepository.GetAllDeals();
                return Ok(deals);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}", Name = "DealById")]
        public async Task<IActionResult> GetDeal(int id)
        {
            try
            {
                var deal = await dealRepository.GetDeal(id);
                if (deal == null)
                {
                    return NotFound();
                }
                return Ok(deal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateDeal(DealDto deal)
        {
            try
            {
                var createddeal = await dealRepository.createDeal(deal);
                return CreatedAtRoute("DealById", new { id = createddeal.Id }, createddeal);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateDeal(int id, DealDto deal)
        {
            try
            {
                var dbDeal = await dealRepository.GetDeal(id);
                if (dbDeal == null)
                    return NotFound();
                await dealRepository.UpdateDeal(id, deal);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteDeal(int id)
        {
            try
            {
                var dbDeal = await dealRepository.GetDeal(id);
                if (dbDeal == null)
                    return NotFound();
                await dealRepository.DeleteDeal(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
