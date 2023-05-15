using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace TestFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessPartnerController : ControllerBase
    {
        private readonly IBusinessPartnerClient _businessPartnerClient;

        public BusinessPartnerController(IBusinessPartnerClient businessPartnerClient)
        {
            _businessPartnerClient = businessPartnerClient;
        }

        [HttpGet]
        public async Task<ActionResult<List<BusinessPartner>>> GetAllBusinessPartners()
        {
            var businessPartners = await _businessPartnerClient.GetAllBusinessPartnersAsync();
            return Ok(businessPartners);
        }

        [HttpGet("{cardCode}")]
        public async Task<ActionResult<BusinessPartner>> GetBusinessPartner(string cardCode)
        {
            var businessPartner = await _businessPartnerClient.GetBusinessPartnerAsync(cardCode);
            return Ok(businessPartner);
        }

        [HttpPost]
        public async Task<ActionResult<BusinessPartner>> CreateBusinessPartner([FromBody] BusinessPartner businessPartner)
        {
            var createdBusinessPartner = await _businessPartnerClient.CreateBusinessPartnerAsync(businessPartner);
            return CreatedAtAction(nameof(GetBusinessPartner), new { cardCode = createdBusinessPartner.CardCode }, createdBusinessPartner);
        }

        [HttpPut("{cardCode}")]
        public async Task<IActionResult> UpdateBusinessPartner(string cardCode, [FromBody] BusinessPartner businessPartner)
        {
            await _businessPartnerClient.UpdateBusinessPartnerAsync(cardCode, businessPartner);
            return NoContent();
        }

        [HttpDelete("{cardCode}")]
        public async Task<IActionResult> DeleteBusinessPartner(string cardCode)
        {
            await _businessPartnerClient.DeleteBusinessPartnerAsync(cardCode);
            return NoContent();
        }

    }
}
