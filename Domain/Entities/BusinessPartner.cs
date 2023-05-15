using System;

namespace Domain.Entities
{
    public class BusinessPartner
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CardName { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string CardCode { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? Ano { get; set; }
    }
}
