using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.ObjectsAndDataStructures
{
    // DTO ou value object - só guarda os dados
    public class AddressDTO
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    // Objeto - encapsula e processa, tem comportamentos internos e os esconde, só expondo o necessário.
    public class Address
    {
        private readonly string _street;
        private readonly string _city;

        public Address(string street, string city)
        {
            _street = street;
            _city = city;
        }

        public string Format()
        {
            return $"{_street}, {_city}";
        }
    }
}
