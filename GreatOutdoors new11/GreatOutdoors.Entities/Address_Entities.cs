using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoors.Entities
{

    public class Address_Entities
    {
        private int _retailerID;
        private int _addressID;
        private string _line1;
        private string _line2;
        private string _city;
        private int _pincode;
        private string _state;
        private string _contactNo;

        public int RetailerID { get => _retailerID; set => _retailerID = value; }
        public int AddressID { get => _addressID; set => _addressID = value; }
        public string Line1 { get => _line1; set => _line1 = value; }
        public string Line2 { get => _line2; set => _line2 = value; }
        public string City { get => _city; set => _city = value; }
        public int Pincode { get => _pincode; set => _pincode = value; }
        public string State { get => _state; set => _state = value; }
        public string ContactNo { get => _contactNo; set => _contactNo = value; }
    }
}
