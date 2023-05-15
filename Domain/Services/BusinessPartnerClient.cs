using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Newtonsoft.Json;

public class BusinessPartnerClient : IBusinessPartnerClient
{
    private readonly HttpClient _httpClient;

    public BusinessPartnerClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://637283b2348e947299f77e08.mockapi.io/b1s/v2/BusinessPartners");
    }

    public async Task<List<BusinessPartner>> GetAllBusinessPartnersAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("business-partners");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        List<BusinessPartner> businessPartners = JsonConvert.DeserializeObject<List<BusinessPartner>>(responseBody);
        return businessPartners;
    }

    public async Task<BusinessPartner> GetBusinessPartnerAsync(string cardCode)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"business-partners/{cardCode}");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        BusinessPartner businessPartner = JsonConvert.DeserializeObject<BusinessPartner>(responseBody);
        return businessPartner;
    }

    public async Task<BusinessPartner> CreateBusinessPartnerAsync(BusinessPartner businessPartner)
    {
        string json = JsonConvert.SerializeObject(businessPartner);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync("business-partners", content);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        BusinessPartner createdBusinessPartner = JsonConvert.DeserializeObject<BusinessPartner>(responseBody);
        return createdBusinessPartner;
    }

    public async Task UpdateBusinessPartnerAsync(string cardCode, BusinessPartner businessPartner)
    {
        var existingBusinessPartner = await GetBusinessPartnerAsync(cardCode);
        existingBusinessPartner.CardName = businessPartner.CardName;

        string json = JsonConvert.SerializeObject(existingBusinessPartner);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PutAsync($"business-partners/{cardCode}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteBusinessPartnerAsync(string cardCode)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync($"business-partners/{cardCode}");
        response.EnsureSuccessStatusCode();
    }
}
