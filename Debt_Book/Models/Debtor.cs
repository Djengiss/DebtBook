using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Responsible for defining the Debtor model class.
// Contains properties that represent attributes of a debtor, such as name and amount owed.
namespace Debt_Book.Models
{
    public class Debtor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [PrimaryKey]
        public string Name { get; set; }

        public List<Debt> Debts { get; set; }
        //public double AmountOwed { get; set; }
    }
}
