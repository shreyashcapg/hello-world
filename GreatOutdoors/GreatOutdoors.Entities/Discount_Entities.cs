using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoors.Entities
{
    public class Discount
    {
        private int _orderID;
        private int _retailerID;
        private double _retailerDiscount;
        private double _categoryDiscount;

        public int OrderID { get => _orderID; set => _orderID = value; }
        public int RetailerID { get => _retailerID; set => _retailerID = value; }
        public double RetailerDiscount { get => _retailerDiscount; set => _retailerDiscount = value; }
        public double CategoryDiscount { get => _categoryDiscount; set => _categoryDiscount = value; }
    }
}
