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
            bool hecho = false;
            Products.add(en);
            return hecho;
        }

        public bool Update(ENProduct en)
        {
            return Products.update(en);
        }

        public bool Read(ENProduct en)
        {
            
        }

        public bool ReadFirst(ENProduct en)
        {

        }

        public bool ReadNext(ENProduct en)
        {

        }

        public bool ReadPrev(ENProduct en)
        {

        }
    }
}
