using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoors.Entities;

namespace GreatOutdoors.DataAccessLayer
{
    public class GuestDAL
    {
        public static List<Address> addressList = new List<Address>();

        public bool AddGuestDAL(Address address)
        {
            bool addressAdded = false;
            try
            {
                addressList.Add(address);
                addressAdded = true;
            }
            catch (SystemException ex)
            {
                throw new GuestPhoneBookException(ex.Message);
            }
            return addressAdded;

        }

        public List<Address> GetAllGuestsDAL()
        {
            return addressList;
        }

        public Address SearchAddressDAL(int searchAddressID)
        {
            Address searchAddress = null;
            try
            {
                foreach (Address address in addressList)
                {
                    if (address.AddressID == searchAddressID)
                    {
                        searchAddress = address;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GuestPhoneBookException(ex.Message);
            }
            return searchAddress;
        }

        public bool UpdateAddressDAL(Address updateAddress)
        {
            bool AddressUpdated = false;
            try
            {
                for (int i = 0; i < AddressList.Count; i++)
                {
                    if (guestList[i].GuestID == updateGuest.GuestID)
                    {
                        updateGuest.GuestName = guestList[i].GuestName;
                        updateGuest.GuestContactNumber = guestList[i].GuestContactNumber;
                        guestUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GuestPhoneBookException(ex.Message);
            }
            return guestUpdated;

        }

        public bool DeleteGuestDAL(int deleteGuestID)
        {
            bool guestDeleted = false;
            try
            {
                Guest deleteGuest = null;
                foreach (Guest item in guestList)
                {
                    if (item.GuestID == deleteGuestID)
                    {
                        deleteGuest = item;
                    }
                }

                if (deleteGuest != null)
                {
                    guestList.Remove(deleteGuest);
                    guestDeleted = true;
                }
            }
            catch (DbException ex)
            {
                throw new GuestPhoneBookException(ex.Message);
            }
            return guestDeleted;

        }

    }
}

}
