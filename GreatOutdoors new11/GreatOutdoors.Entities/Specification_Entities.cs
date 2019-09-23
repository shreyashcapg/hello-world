using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoors.Entities
{
    public class Specification
    {
        private int _productID;
        private int _specificationID;
        private string _color;
        private int _size;
        private string _techSpec;


        public int ProductID { get => _productID; set => _productID = value; }
        public int SpecificationID { get => _specificationID; set => _specificationID = value; }
        public string Color { get => _color; set => _color = value; }
        public int Size { get => _size; set => _size = value; }
        public string Techspec { get => _techSpec; set => _techSpec = value; }

    }
}
