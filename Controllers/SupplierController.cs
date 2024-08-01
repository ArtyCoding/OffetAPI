using Microsoft.AspNetCore.Mvc;
using OfferAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfferAPI.Controllers
{
    [Route("api/Supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        // GET: api/<SupplierController>
        [HttpGet("getMostPopular")]
        public async Task<IActionResult> GetPopularSuppliers()
        {
            var suppliers = await _supplierRepository.GetPopularSuppliers();
            if (suppliers == null)
            {
                return NotFound();
            }
            return Ok(suppliers);
        }
    }
}
