using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Responsible for defining the Debt model class.
// Contains properties that represent attributes of a debt, such as description and amount.
namespace DebtBook.Models
{
    public class Debt
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string DebtorName { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }
    }
}
