using System;
using si.nkbm.porfu.DAO;
using Converter;
using Newtonsoft.Json;

namespace si.nkbm.porfu.DTO
{
    public class FatcaXmlBean
    {

        [JsonConverter(typeof(CustomDateTimeConverter))]
        [DataFieldAttribute("Datum")]
        public DateTime Datum { get; set; }

        [DataFieldAttribute("ReportType")]
        public string ReportType { get; set; }

        [DataFieldAttribute("Type")]
        public string Type { get; set; }

        [DataFieldAttribute("TIN")]
        [DataSearchAttribute("TIN")]
        public string Tin { get; set; }

        [DataFieldAttribute("TINIssuedBy")]
        public string TinIssuedBy { get; set; }

        [DataFieldAttribute("ResCountryCode")]
        [DataSearchAttribute("ResCountryCode")]
        public string ResCountryCode { get; set; }

        [DataFieldAttribute("FirstName")]
        [DataSearchAttribute("FirstName")]
        public string FirstName { get; set; }

        [DataFieldAttribute("LastName")]
        [DataSearchAttribute("LastName")]
        public string LastName { get; set; }

        [DataFieldAttribute("Name")]
        [DataSearchAttribute("Name")]
        public string Name { get; set; }

        [DataFieldAttribute("CountryCode")]
        public string CountryCode { get; set; }

        [DataFieldAttribute("Street")]
        public string Street { get; set; }

        [DataSearchAttribute("City")]
        [DataFieldAttribute("City")]
        public string City { get; set; }

        [DataFieldAttribute("PostCode")]
        public string PostCode { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        [DataFieldAttribute("BirthDate")]
        public DateTime BirthDate { get; set; }

        [DataSearchAttribute("AccountNumber")]
        [DataFieldAttribute("AccountNumber")]
        public string AccountNumber { get; set; }

        [DataFieldAttribute("AccountNumberType")]
        public string AccountNumberType { get; set; }

        [DataFieldAttribute("AcctHolderType")]
        public string AcctHolderType { get; set; }

        [DataSearchAttribute("AccountDescription")]
        [DataFieldAttribute("AccountDescription")]
        public string AccountDescription { get; set; }

        [DataFieldAttribute("AccountBalanceCurrCode")]
        public string AccountBalanceCurrCode { get; set; }

        [DataFieldAttribute("AccountBalance")]
        public decimal AccountBalance { get; set; }

        [DataFieldAttribute("AccountBalanceUSD")]
        public decimal AccountBalanceUSD { get; set; }

        [DataFieldAttribute("AccountBalanceEUR")]
        public decimal AccountBalanceEUR { get; set; }

        [DataFieldAttribute("Payment")]
        public decimal Payment { get; set; }

        [DataFieldAttribute("PaymentType")]
        public string PaymentType { get; set; }

        [DataFieldAttribute("PaymentCurrencyCode")]
        public string PaymentCurrencyCode { get; set; }

        [DataFieldAttribute("KomitentKLJ")]
        public int KomitentKLJ { get; set; }

        [DataFieldAttribute("ControllingPersonRead")]
        public bool ControllingPersonRead { get; set; }

        [DataFieldAttribute("ClosedAccount")]
        public bool ClosedAccount { get; set; }

        [DataFieldAttribute("DormantAccount")]
        public bool DormantAccount { get; set; }

        [DataFieldAttribute("TaxCode")]
        public string TaxCode { get; set; }

        [DataFieldAttribute("TaxCode2")]
        public string TaxCode2 { get; set; }

        [DataFieldAttribute("TaxCode3")]
        public string TaxCode3 { get; set; }

        [DataFieldAttribute("ResCountryCode2")]
        public string ResCountryCode2 { get; set; }

        [DataFieldAttribute("ResCountryCode3")]
        public string ResCountryCode3 { get; set; }

    }
}
