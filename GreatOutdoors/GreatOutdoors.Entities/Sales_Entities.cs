using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoors.Entities
{
    public class Sales
    {
        private int _salesPersonId;
        private string _salesPersonName;
        private List<int>[] salesHistory;

        public int SalesPersonId { get => _salesPersonId; set => _salesPersonId = value; }
        public string SalesPersonName { get => _salesPersonName; set => _salesPersonName = value; }
        public List<int>[] SalesHistory { get => salesHistory; set => salesHistory = value; }
    }
}
