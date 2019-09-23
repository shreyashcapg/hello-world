using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoors.Entities;
using GreatOutdoors.Exceptions;

namespace GreatOutdoors.DataAccessLayer
{
    public class Discount_DAL
    {
        public static List<Discount_Entities> discountList = new List<Discount_Entities>();

        public bool AddDiscountDAL(Discount_Entities discount)
        {
            bool discountAdded;
            try
            {
                discountList.Add(discount);
                discountAdded = true;
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return discountAdded;

        }

        public List<Discount_Entities> GetAllDiscountDAL()
        {
            return discountList;
        }

        public Discount_Entities SearchDiscountDAL(int searchRetailerID, int searchOrderID)
        {
            Discount_Entities searchDiscount = null;
            try
            {
                foreach (Discount_Entities discount in discountList)
                {
                    if ((discount.OrderID == searchOrderID) && (discount.RetailerID == searchRetailerID))
                    {
                        searchDiscount = discount;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return searchDiscount;
        }

        public bool UpdatedDiscountDAL(Discount_Entities updateDiscount)
        {
            bool DiscountUpdated = false;
            try
            {
                for (int i = 0; i < discountList.Count; i++)
                {
                    if ((discountList[i].RetailerID == updateDiscount.RetailerID) && (discountList[i].OrderID == updateDiscount.OrderID))
                    {
                        discountList[i].RetailerDiscount = updateDiscount.RetailerDiscount;
                        discountList[i].CategoryDiscount = updateDiscount.CategoryDiscount;
                        DiscountUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return DiscountUpdated;

        }

        public bool DeleteDiscountDAL(int deleteRetailerID, int deleteOrderID)
        {
            bool discountDeleted = false;
            try
            {
                Discount_Entities deleteDiscount = null;
                foreach (Discount_Entities item in discountList)
                {
                    if ((item.OrderID == deleteOrderID) && (item.RetailerID == deleteRetailerID))
                    {
                        deleteDiscount = item;
                    }
                }

                if (deleteDiscount != null)
                {
                    discountList.Remove(deleteDiscount);
                    discountDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return discountDeleted;

        }

    }
}
