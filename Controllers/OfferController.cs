using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfferAPI.Data;
using OfferAPI.Dto;
using OfferAPI.Interfaces;
using OfferAPI.Models;

namespace OfferAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly OfferAPIContext _context;
        private readonly IOfferRepository _offerRepository;

        public OfferController(OfferAPIContext context, IOfferRepository offerRepository)
        {
            _context = context;
            _offerRepository = offerRepository;
        }

        [HttpGet("find/{searchingValue}")]
        public async Task<IActionResult> FindOffersAsync(string searchingValue)
        {
            var offers = await _offerRepository.FindOffers(searchingValue);
            if(!offers.Any())
            {
                return NotFound();
            }
            return Ok(offers);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOfferAsync(CreateOfferDto offer)
        {
            var newoffer = await _offerRepository.CreateOffer(offer);
            if (newoffer.Provider != null)
            {
                return CreatedAtAction("GetOfferAsync", new { id = newoffer.Id }, newoffer);
            }
            return BadRequest();
        }
    }
}
