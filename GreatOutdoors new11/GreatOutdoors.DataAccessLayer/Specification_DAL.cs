using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoors.Entities;
using GreatOutdoors.Exceptions;

namespace GreatOutdoors.DataAccessLayer
{
    public class Specification_DAL
    {
        public static List<Specification> specificationList = new List<Specification>();

        public bool AddSpecificationDAL(Specification newSpecification)
        {
            bool specificationAdded = false;
            try
            {
                specificationList.Add(newSpecification);
                specificationAdded = true;
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return specificationAdded;

        }

        public List<Specification> GetAllSpecificationsDAL()
        {
            return specificationList;
        }

        public Specification SearchSpecificationDAL(int searchSpecificationID)
        {
            Specification searchSpecification = null;
            try
            {
                foreach (Specification item in specificationList)
                {
                    if (item.SpecificationID == searchSpecificationID)
                    {
                        searchSpecification = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return searchSpecification;
        }


        public bool UpdateSpecificationDAL(Specification updateSpecification)
        {
            bool specificationUpdated = false;
            try
            {
                for (int i = 0; i < specificationList.Count; i++)
                {
                    if (specificationList[i].SpecificationID == updateSpecification.SpecificationID)
                    {
                        updateSpecification.ProductID = specificationList[i].ProductID;
                        updateSpecification.Color = specificationList[i].Color;
                        updateSpecification.Size = specificationList[i].Size;
                        updateSpecification.Techspec = specificationList[i].Techspec;
                        specificationUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return specificationUpdated;

        }

        public bool DeleteSpecificationDAL(int deleteSpecificationID)
        {
            bool specificationDeleted = false;
            try
            {
                Specification deleteSpecification = null;
                foreach (Specification item in specificationList)
                {
                    if (item.SpecificationID == deleteSpecificationID)
                    {
                        deleteSpecification = item;
                    }
                }

                if (deleteSpecification != null)
                {
                    specificationList.Remove(deleteSpecification);
                    specificationDeleted = true;
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return specificationDeleted;

        }

    }
}
