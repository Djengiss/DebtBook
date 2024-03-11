using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Responsible for defining the Debt model class.
// Contains properties that represent attributes of a debt, such as description and amount.
namespace Debt_Book.Models
{
    public class Debt
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int DebtorId { get; set; }

        public string Date { get; set; }

        public double Amount { get; set; }
    }
}
