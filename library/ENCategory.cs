using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
        public class ENCategory
    {
        public int _id;
        public string _name;
        public int Id
        {
            get { return _id; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "La categoria es menor que 0");
                }
                else
                {
                    _id = value;
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
        public ENCategory()
        {

        }

        public ENCategory(int id, string name)
        {
            _id = Id;
            Name = name;
            
        }
    }
    }

