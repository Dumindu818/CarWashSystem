using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRAutoCare
{
    internal class Trans
    {
        static string adminID;
        static string cashierID;
        static int serviceNumber;

        static Boolean loginc;
        
        public static string AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }
        public static string CashierID
        {
            get { return cashierID; }
            set { cashierID = value; }
        }

        public static Boolean Loginc
        {
            get { return loginc; }
            set { loginc = value; }
        }

        public static int ServiceNumber
        {
            get { return serviceNumber; }
            set { serviceNumber = value; }
        }
    }
}
