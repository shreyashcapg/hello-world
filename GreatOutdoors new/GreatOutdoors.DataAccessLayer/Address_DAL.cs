using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoors.Entities;
using GreatOutdoors.Exceptions;

namespace GreatOutdoors.DataAccessLayer
{
    public class Address_DAL
    {
        public static List<Address_Entities> addressList = new List<Address_Entities>();

        public bool AddAddressDAL(Address_Entities address)
        {
            bool addressAdded;
            try
            {
                addressList.Add(address);
                addressAdded = true;
            }
            catch (SystemException ex)
            {
                throw new AddressException(ex.Message);
            }
            return addressAdded;

        }

        public List<Address_Entities> GetAllAddressDAL()
        {
            return addressList;
        }

        public Address_Entities SearchAddressDAL(int searchAddressID)
        {
            Address_Entities searchAddress = null;
            try
            {
                foreach (Address_Entities address in addressList)
                {
                    if (address.AddressID == searchAddressID)
                    {
                        searchAddress = address;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new AddressException(ex.Message);
            }
            return searchAddress;
        }

        public bool UpdateAddressDAL(Address_Entities updateAddress)
        {
            bool AddressUpdated = false;
            try
            {
                for (int i = 0; i < addressList.Count; i++)
                {
                    if (addressList[i].AddressID == updateAddress.AddressID)
                    {
                        addressList[i].Line1 = updateAddress.Line1;
                        addressList[i].Line2 = updateAddress.Line2;
                        addressList[i].City = updateAddress.City;
                        addressList[i].Pincode = updateAddress.Pincode;
                        addressList[i].State = updateAddress.State;
                        addressList[i].ContactNo = updateAddress.ContactNo;
                        AddressUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new AddressException(ex.Message);
            }
            return AddressUpdated;

        }

        public bool DeleteAddressDAL(int deleteAddressID)
        {
            bool addressDeleted = false;
            try
            {
                Address_Entities deleteAddress = null;
                foreach (Address_Entities item in addressList)
                {
                    if (item.AddressID == deleteAddressID)
                    {
                        deleteAddress = item;
                    }
                }

                if (deleteAddress != null)
                {
                    addressList.Remove(deleteAddress);
                    addressDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw new AddressException(ex.Message);
            }
            return addressDeleted;

        }

    }
}
