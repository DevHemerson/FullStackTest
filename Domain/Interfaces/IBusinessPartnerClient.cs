using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBusinessPartnerClient
    {
        Task<List<BusinessPartner>> GetAllBusinessPartnersAsync();
        Task<BusinessPartner> GetBusinessPartnerAsync(string cardCode);
        Task<BusinessPartner> CreateBusinessPartnerAsync(BusinessPartner businessPartner);
        Task UpdateBusinessPartnerAsync(string cardCode, BusinessPartner businessPartner);
        Task DeleteBusinessPartnerAsync(string cardCode);
    }
}
