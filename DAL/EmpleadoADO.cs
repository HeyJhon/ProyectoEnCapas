using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ML;
namespace DAL
{
    public class EmpleadoADO
    {
        private string cadena = @"Server=server;Database=Test;User Id=sa;Password=password";
        public EmpleadoADO()
        {

        }
        public List<Empleado> GetEmpleados()
        {
            try
            {
                using(SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    string query = "SELECT * FROM Empleado";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    List<Empleado> listaEmpleados = new List<Empleado>();

                    while (sqlDataReader.Read())
                    {
                        int id = int.Parse(sqlDataReader["Id"].ToString());
                        string nombre = sqlDataReader["Nombre"].ToString();
                        byte edad =byte.Parse(sqlDataReader["Edad"].ToString());
                        decimal salario = decimal.Parse(sqlDataReader["Salario"].ToString());

                        Empleado empleado = new Empleado(id, nombre, edad, salario);

                        listaEmpleados.Add(empleado);
                    }
                    sqlDataReader.Close();

                    return listaEmpleados;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
