using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoors.Entities;
using GreatOutdoors.DataAccessLayer;
using GreatOutdoors.Exceptions;

namespace GreatOutdoors.BuisnessLayer
{
    public class Discount_BL
    {
        private static bool ValidateDiscount(Discount_Entities discount)
        {
            StringBuilder sb = new StringBuilder();
            bool validDiscount = true;
            if (discount.OrderID == 0)
            {
                validDiscount = false;
                sb.Append(Environment.NewLine + "OrderID Required");

            }
            if (discount.RetailerID == 0)
            {
                validDiscount = false;
                sb.Append(Environment.NewLine + "RetailerID Required");

            }
            if (discount.CategoryDiscount == 0)
            {
                validDiscount = false;
                sb.Append(Environment.NewLine + "Category Discount Required");
            }
            if (discount.RetailerDiscount == 0)
            {
                validDiscount = false;
                sb.Append(Environment.NewLine + "Retailer Discount Required");
            }
            if (validDiscount == false)
                throw new Discount_Exception(sb.ToString());
            return validDiscount;
        }

        public static bool AddDiscountBL(Discount_Entities newDiscount)
        {
            bool DiscountAdded = false;
            try
            {
                if (ValidateDiscount(newDiscount))
                {
                    Discount_DAL discountDAL = new Discount_DAL();
                    DiscountAdded = discountDAL.AddDiscountDAL(newDiscount);
                }
            }
            catch (Discount_Exception)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DiscountAdded;
        }

        public static List<Discount_Entities> GetAllDiscountBL()
        {
            List<Discount_Entities> discountList = null;
            try
            {
                Discount_DAL discountDAL = new Discount_DAL();
                discountList = discountDAL.GetAllDiscountDAL();
            }
            catch (Discount_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return discountList;
        }

        public static Discount_Entities SearchDiscountBL(int searchRetailerID, int searchOrderID)
        {
            Discount_Entities searchDiscount = null;
            try
            {
                Discount_DAL discountDAL = new Discount_DAL();
                searchDiscount = discountDAL.SearchDiscountDAL(searchRetailerID,searchOrderID);
            }
            catch (Discount_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchDiscount;

        }

        public static bool UpdateDiscountBL(Discount_Entities updateDiscount)
        {
            bool discountUpdated = false;
            try
            {
                if (ValidateDiscount(updateDiscount))
                {
                    Discount_DAL discountDAL = new Discount_DAL();
                    discountUpdated = discountDAL.UpdatedDiscountDAL(updateDiscount);
                }
            }
            catch (Discount_Exception)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return discountUpdated;
        }

        public static bool DeleteDiscountBL(int deleteRetailerID, int deleteOrderID)
        {
            bool discountDeleted = false;
            try
            {
                if ((deleteOrderID > 0) && (deleteRetailerID > 0))
                {
                    Discount_DAL discountDAL = new Discount_DAL();
                    discountDeleted = discountDAL.DeleteDiscountDAL(deleteRetailerID,deleteOrderID);
                }
                else
                {
                    throw new Discount_Exception("Invalid Order ID and Retailer ID");
                }
            }
            catch (Discount_Exception)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return discountDeleted;
        }
    }
}
