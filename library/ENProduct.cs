﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static library.ENProduct;
namespace library
{
    class ENProduct
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
                _code = value;
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
            }
        }
        public float Price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }
        public int Category
        {
            get { return _category; }
            set
            {
                _category = value;
            }
        }
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set
            {
                _creationDate = value;
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

        }

    }
}
