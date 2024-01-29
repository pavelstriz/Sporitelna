using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sporitelna;

namespace Sporitelna
{
    class ColumnFilters
    {
        
        public static class Users
        {
            public static ContextMenu cmDgvUsersHeader;
            public static MenuItem miDefault, miId, miTitul, miFirstName, miLastName, miAddress, miNationality, miBirth, miCompany;
            
        }
        public static class Contracts
        {
            public static ContextMenu cmDgvContractsHeader;
            public static MenuItem miDefault, miId, miFirstName, miLastName, miFullName, miFinalAmount, miInterestRate, 
                miTotal, miCurrency, miDateSince, miDateTo, miDescription, miStatus;

        }
    }
}
