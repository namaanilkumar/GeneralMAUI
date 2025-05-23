using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralMAUI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class User1
    {
        public string Status { get; set; }
        public int Code { get; set; }
        public string Locale { get; set; }
        public string Seed { get; set; }
        public int Total { get; set; }
        public List<Person> Data { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public Address Address { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string Country_Code { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
