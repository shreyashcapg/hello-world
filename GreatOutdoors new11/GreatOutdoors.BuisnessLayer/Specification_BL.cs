using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoors.Exceptions;
using GreatOutdoors.DataAccessLayer;
using GreatOutdoors.Entities;

namespace GreatOutdoors.BuisnessLayer
{
    class Specification_BL
    {
        private static bool ValidateSpecification(Specification specification)
        {
            StringBuilder sb = new StringBuilder();
            bool validSpecification = true;
            if (specification.SpecificationID <= 0)
            {
                validSpecification = false;
                sb.Append(Environment.NewLine + "Invalid Specification ID");

            }

            if (specification.Color == null)
            {
                validSpecification = false;
                sb.Append(Environment.NewLine + "Invalid Color Specification");

            }

            if (specification.Size <= 0)
            {
                validSpecification = false;
                sb.Append(Environment.NewLine + "Invalid Specification Value");
            }
            if (specification.Techspec == null)
            {
                validSpecification = false;
                sb.Append(Environment.NewLine + "Invalid Technical Specification");

            }


            if (validSpecification == false)
                throw new GreatOutdoorsException(sb.ToString());
            return validSpecification;
        }

        public static bool AddSpecificationBL(Specification newSpecification)
        {
            bool specificationAdded = false;
            try
            {
                if (ValidateSpecification(newSpecification))
                {
                    Specification_DAL specificationDAL = new Specification_DAL();
                    specificationAdded = specificationDAL.AddSpecificationDAL(newSpecification);
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

            return specificationAdded;
        }

        public static List<Specification> GetAllSpecificationsBL()
        {
            List<Specification> specificationList = null;
            try
            {
                Specification_DAL specificationDAL = new Specification_DAL();
                specificationList = specificationDAL.GetAllSpecificationsDAL();
            }
            catch (GreatOutdoorsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return specificationList;
        }

        public static Specification SearchSpecificationBL(int searchSpecificationID)
        {
            Specification searchSpecification = null;
            try
            {
                Specification_DAL specificationDAL = new Specification_DAL();
                searchSpecification = specificationDAL.SearchSpecificationDAL(searchSpecificationID);
            }
            catch (GreatOutdoorsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchSpecification;

        }

        public static bool UpdateSpecificationBL(Specification updateSpecification)
        {
            bool specificationUpdated = false;
            try
            {
                if (ValidateSpecification(updateSpecification))
                {
                    Specification_DAL specificationDAL = new Specification_DAL();
                    specificationUpdated = specificationDAL.UpdateSpecificationDAL(updateSpecification);
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

            return specificationUpdated;
        }

        public static bool DeleteSpecificationBL(int deleteSpecificationID)
        {
            bool specificationDeleted = false;
            try
            {
                if (deleteSpecificationID > 0)
                {
                    Specification_DAL specificationDAL = new Specification_DAL();
                    specificationDeleted = specificationDAL.DeleteSpecificationDAL(deleteSpecificationID);
                }
                else
                {
                    throw new GreatOutdoorsException("Invalid Specification ID");
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

            return specificationDeleted;
        }


    }

}
}
