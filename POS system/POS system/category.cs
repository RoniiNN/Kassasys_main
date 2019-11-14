using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_system
{
    public class category
    {
        string categoryString;
        public category(string s)
        {
            categoryString = s;
        }

        public string CategoryString
        {
            get
            {
                return categoryString;
            }
            set
            {
                categoryString = value;
            }
        }


    }
}
