using System.ComponentModel.DataAnnotations;

namespace DotNet.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        private string CompanyName { get; set; }

        public Company() { }
        public Company(string CompanyName)
        {
            this.CompanyName = CompanyName;
        }

        public override string ToString()
        {
            return CompanyName;
        }
    }
}
