using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static library.ENProduct;
namespace library
{
    public class ENProduct
    {
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;
        public string Code
        {
            get { return _code; }
            set
            { 
                if(value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _code = value;

                }
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _name = value;

                }
            }
        }
        public int Amount
        {
            get { return _amount; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _amount = value;

                }
            }
        }
        public float Price
        {
            get { return _price; }
            set
            {
                if(value < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _price = value;

                }
            }
        }
        public int Category
        {
            get { return _category; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _category = value;

                }
            }
        }
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _creationDate = value;

                }
            }
        }

        public ENProduct()
        {

        }

        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            Code = code;
            Name = name;
            Amount = amount;
            Price = price;
            Category = category;
            CreationDate = creationDate;
        }

        public bool Create()
        {
            CADProduct cad = new CADProduct();

            bool hecho = cad.Create(this);

            return hecho;
        }

        public bool Update()
        {
            bool hecho;
            CADProduct cad = new CADProduct();
            hecho = cad.Update(this);
            return hecho;
        }

        public bool Delete(ENProduct en)
        {
            bool hecho;
            CADProduct cad = new CADProduct();
            hecho = cad.Delete(this);
            return hecho;
        }

        public bool Read(ENProduct en)
        {
            bool hecho;
            CADProduct cad = new CADProduct();
            hecho = cad.Read(this);
            return hecho;
        }

        public bool ReadFirst(ENProduct en)
        {
            bool hecho;
            CADProduct cad = new CADProduct();
            hecho = cad.ReadFirst(this);
            return hecho;
        }


        public bool ReadNext(ENProduct en)
        {
            bool hecho;
            CADProduct cad = new CADProduct();
            hecho = cad.ReadNext(this);
            return hecho;
        }

        public bool ReadPrev(ENProduct en)
        {
            bool hecho;
            CADProduct cad = new CADProduct();
            hecho = ReadPrev(this);
            return hecho;
        }

    }
}
