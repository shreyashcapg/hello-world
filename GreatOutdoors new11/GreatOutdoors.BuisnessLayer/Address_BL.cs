using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoors.Entities;
using GreatOutdoors.Exceptions;
using GreatOutdoors.DataAccessLayer;

namespace GreatOutdoors.BuisnessLayer
{
    public class Address_BL
    {
        private static bool ValidateAddress(Address_Entities address)
        {
            StringBuilder sb = new StringBuilder();
            bool validAddress = true;
            if (address.Line1 == string.Empty)
            {
                validAddress = false;
                sb.Append(Environment.NewLine + "Address Line1 Required");

            }
            if (address.Line2 == string.Empty)
            {
                validAddress = false;
                sb.Append(Environment.NewLine + "Address Line2 Required");

            }
            if (address.ContactNo.Length != 10 || address.ContactNo.Length != 7)
            {
                validAddress = false;
                sb.Append(Environment.NewLine + "Required 7 or 10 Digit Contact Number");
            }
            if (address.City == null)
            {
                validAddress = false;
                sb.Append(Environment.NewLine + "City Name Required");
            }
            if (address.Pincode.ToString().Length != 6)
            {
                validAddress = false;
                sb.Append(Environment.NewLine + "Invalid Pincode");
            }
            if (address.State == null)
            {
                validAddress = false;
                sb.Append(Environment.NewLine + "State Name Required");
            }
            if (validAddress == false)
                throw new GreatOutdoorsException(sb.ToString());
            return validAddress;
        }

        public static bool AddAddressBL(Address_Entities newAddress)
        {
            bool AddressAdded = false;
            try
            {
                if (ValidateAddress(newAddress))
                {
                    Address_DAL addressDAL = new Address_DAL();
                    AddressAdded = addressDAL.AddAddressDAL(newAddress);
                }
            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return AddressAdded;
        }

        public static List<Address_Entities> GetAllAddressBL()
        {
            List<Address_Entities> addressList = null;
            try
            {
                Address_DAL addressDAL = new Address_DAL();
                addressList = addressDAL.GetAllAddressDAL();
            }
            catch (GreatOutdoorsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return addressList;
        }

        public static Address_Entities SearchAddressBL(int searchAddressID)
        {
            Address_Entities searchAddress = null;
            try
            {
                Address_DAL addressDAL = new Address_DAL();
                searchAddress = addressDAL.SearchAddressDAL(searchAddressID);
            }
            catch (GreatOutdoorsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchAddress;

        }

        public static bool UpdateAddressBL(Address_Entities updateAddress)
        {
            bool addressUpdated = false;
            try
            {
                if (ValidateAddress(updateAddress))
                {
                    Address_DAL addressDAL = new Address_DAL();
                    addressUpdated = addressDAL.UpdateAddressDAL(updateAddress);
                }
            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return addressUpdated;
        }

        public static bool DeleteAddesstBL(int deleteAddressID)
        {
            bool addressDeleted = false;
            try
            {
                if (deleteAddressID > 0)
                {
                    Address_DAL addressDAL = new Address_DAL();
                    addressDeleted = addressDAL.DeleteAddressDAL(deleteAddressID);
                }
                else
                {
                    throw new GreatOutdoorsException("Invalid Guest ID");
                }
            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return addressDeleted;
        }
    }
}
