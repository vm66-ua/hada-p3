using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADProduct
    {
        private string constring;
        public CADProduct()
        {
            constring = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security=True";
        }

        public bool Create(ENProduct en)
        {
            bool hecho;

            return hecho;
        }
    }
}
