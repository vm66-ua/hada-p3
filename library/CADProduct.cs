﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

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
            using (SqlConnection nueva = new SqlConnection(constring))
            {
                string accion = "INSERT INTO Products (Code, Name, Amount, Price, Category, CreationDate) VALUES (@Code, @Name, @Amount, @Price, @Category, @CreationDate)";
                SqlCommand comando = new SqlCommand(accion, nueva);
                comando.Parameters.AddWithValue("@Amount", en.Amount);
                comando.Parameters.AddWithValue("@Price", en.Price);
                comando.Parameters.AddWithValue("@Name", en.Name);
                comando.Parameters.AddWithValue("@Code", en.Code);
                comando.Parameters.AddWithValue("@CreationDate", en.CreationDate);
                comando.Parameters.AddWithValue("@Category", en.Category);
                try
                {
                    nueva.Open();
                    int filas = comando.ExecuteNonQuery();
                    if(filas > 0)
                    {
                        hecho = true;
                    }
                }
                catch(Exception excepcion)
                {
                    Console.WriteLine("Error en la creación" + excepcion.Message);
                }
            }
            return hecho;
        }

        public bool Update(ENProduct en)
        {
            bool hecho = false;
            using (SqlConnection nueva = new SqlConnection(constring))
            {
                string actual = "UPDATE Products SET Name=@Name, Amount=@Amount, Price=@Price, Category=@Category, CreationDate=@CreationDate WHERE Code=@Code";
                SqlCommand accion = new SqlCommand(actual, nueva);
                accion.Parameters.AddWithValue("@Code", en.Code);
                accion.Parameters.AddWithValue("@Name", en.Name);
                accion.Parameters.AddWithValue("@Amount", en.Amount);
                accion.Parameters.AddWithValue("@Price", en.Price);
                accion.Parameters.AddWithValue("@Category", en.Category);
                accion.Parameters.AddWithValue("@CreationDate", en.CreationDate);

                try
                {
                    nueva.Open();
                    int rows = accion.ExecuteNonQuery();
                    if(rows > 0)
                    {
                        hecho = true;
                    }
                }
                catch (Exception excepcion)
                {
                    Console.WriteLine("Error en la actualización " + excepcion.Message);
                }
            }
            return hecho;

        }

        public bool Read(ENProduct en)
        {
            bool hecho = false;
            using (SqlConnection nueva = new SqlConnection(constring))
            {
                string accion = "SELECT * FROM Products WHERE Code=@Code";
                SqlCommand cmd = new SqlCommand(accion, nueva);
                cmd.Parameters.AddWithValue("@Code", en.Code);

                try
                {
                    nueva.Open();
                    SqlDataReader leer = cmd.ExecuteReader();
                    if (leer.Read())
                    {
                        en.Name = leer["Name"].ToString();
                        en.Amount = Convert.ToInt32(leer["Amount"]);
                        en.Price = Convert.ToSingle(leer["Price"]);
                        en.Category = Convert.ToInt32(leer["Category"]);
                        en.CreationDate = Convert.ToDateTime(leer["CreationDate"]);
                        hecho = true;
                    }
                    leer.Close();
                }
                catch (Exception excepcion)
                {
                    Console.WriteLine("Error en la lectura " + excepcion.Message);
                }
            }
            return hecho;
        }

        public bool ReadFirst(ENProduct en)
        {
            bool hecho = false;
            using (SqlConnection nueva = new SqlConnection(constring))
            {
                string accion = "SELECT TOP 1 * FROM Products ORDER BY Code ASC";
                SqlCommand comando = new SqlCommand(accion, nueva);
            
                try
                {
                    nueva.Open();
                    SqlDataReader lector = comando.ExecuteReader();
                    
                    if (lector.Read())
                    {
                        hecho = true;
                        en.Code = lector["Code"].ToString();
                        en.Name = lector["Name"].ToString();
                        en.Amount = Convert.ToInt32(lector["Amount"]);
                        en.Price = Convert.ToSingle(lector["Price"]);
                        en.Category = Convert.ToInt32(lector["Category"]);
                        en.CreationDate = Convert.ToDateTime(lector["CreationDate"]);
                    }
                }
                catch (Exception excepcion)
                {
                    Console.WriteLine("Error en la lectura del primero " + excepcion.Message);
                }
            }
            return hecho;
        }

        public bool ReadNext(ENProduct en)
        {
            bool hecho = false;
            using (SqlConnection nueva = new SqlConnection(constring))
            {
                string accion = "SELECT TOP 1 * FROM Products WHERE Code > @Code ORDER BY Code ASC";
                SqlCommand comando = new SqlCommand(accion, nueva);
                comando.Parameters.AddWithValue("@Code", en.Code);

                try
                {
                    nueva.Open();
                    SqlDataReader lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        en.Code = lector["Code"].ToString();
                        en.Name = lector["Name"].ToString();
                        en.Amount = Convert.ToInt32(lector["Amount"]);
                        en.Price = Convert.ToSingle(lector["Price"]);
                        en.Category = Convert.ToInt32(lector["Category"]);
                        en.CreationDate = Convert.ToDateTime(lector["CreationDate"]);
                        hecho = true;
                    }
                    

                }
                catch (Exception excepcion)
                {
                    Console.WriteLine("Error en la lectura del siguiente elemento " + excepcion.Message);
                }
            }
            return hecho;
        }

        public bool ReadPrev(ENProduct en)
        {
            bool hecho = false;
            using (SqlConnection nueva = new SqlConnection(constring))
            {
                string accion = "SELECT TOP 1 * FROM Products WHERE Code < @Code ORDER BY Code DESC";
                SqlCommand comando = new SqlCommand(accion, nueva);
                comando.Parameters.AddWithValue("@Code", en.Code);

                try
                {

                    nueva.Open();
                    SqlDataReader lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        hecho = true;
                        en.Code = lector["Code"].ToString();
                        en.Name = lector["Name"].ToString();
                        en.Amount = Convert.ToInt32(lector["Amount"]);
                        en.Price = Convert.ToSingle(lector["Price"]);
                        en.Category = Convert.ToInt32(lector["Category"]);
                        en.CreationDate = Convert.ToDateTime(lector["CreationDate"]);
                    }
                    

                }
                catch (Exception excepcion)
                {
                    Console.WriteLine("Error en la lectura del elemento anterior " + excepcion.Message);
                }
            }
            return hecho;
        }

        public bool Delete(ENProduct en) {
            bool hecho = false;
            using (SqlConnection nueva = new SqlConnection(constring))
            {
                string accion = "DELETE FROM Products WHERE Code = @Code";
                SqlCommand comando = new SqlCommand(accion, nueva);
                comando.Parameters.AddWithValue("@Code", en.Code);
                try
                {
                    nueva.Open();
                    int filas = comando.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        hecho = true;
                    }
                }
                catch (Exception excepcion)
                {
                    Console.WriteLine("Error al eliminar el producto" + excepcion.Message);
                }
            }
            return hecho;

        }
    }
}
