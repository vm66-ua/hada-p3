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
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El código está vacío o es nulo");
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre está vacío o es nulo");
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
                    throw new ArgumentOutOfRangeException("La cantidad es negativa");
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
                    throw new ArgumentOutOfRangeException("El precio es menor que 1");
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
                    throw new ArgumentOutOfRangeException(nameof(value), "La categoria es menor que 0");
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
                if(value == DateTime.MinValue)
                {
                    throw new ArgumentException("La fecha es incorrecta", nameof(value));
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

        public bool Delete()
        {
            bool hecho;
            CADProduct cad = new CADProduct();
            hecho = cad.Delete(this);
            return hecho;
        }

        public bool Read()
        {
            bool hecho;
            CADProduct cad = new CADProduct();
            hecho = cad.Read(this);
            return hecho;
        }

        public bool ReadFirst()
        {
            bool hecho;
            CADProduct cad = new CADProduct();
            hecho = cad.ReadFirst(this);
            return hecho;
        }


        public bool ReadNext()
        {
            bool hecho;
            CADProduct cad = new CADProduct();
            hecho = cad.ReadNext(this);
            return hecho;
        }

        public bool ReadPrev()
        {
            bool hecho;
            CADProduct cad = new CADProduct();
            hecho = cad.ReadPrev(this);
            return hecho;
        }

    }
}
