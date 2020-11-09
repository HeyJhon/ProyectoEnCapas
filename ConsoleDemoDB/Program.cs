using System;
using System.Data.SqlClient;
using ML;
using BL;
using System.Collections.Generic;

namespace ConsoleDemoDB
{
    class Program
    {
        static string cadenaDeConexion = string.Empty;
        static SqlConnection conexion = null;
        static SqlCommand mySqlCommand = null;
        static SqlDataReader mySqlDataReader = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Trabajando con Base de datos en C#");
            EmpleadoBL contexto = new EmpleadoBL();
            List<Empleado> lista = contexto.GetEmpleados();

            foreach (Empleado item in lista)
            {
                Console.WriteLine(item.Nombre);
            }
            //ConectarASQLServer();
            //MostrarDatosDeEmpleado();
            //InsertarNuevoEmpleado("David", 34, 600.00M);
            //ActualizarEmpleado("Juan", 1500);
            //EliminarEmpleado();
            //CerrarConexion();
        }

        private static void ConectarASQLServer()
        {
            try
            {
                //TODO: Cambiar tus datos por los de tu Base de datos
                cadenaDeConexion = @"Server=server;Database=Test;User Id=sa;Password=password";
                conexion = new SqlConnection(cadenaDeConexion);
                conexion.Open();
                Console.WriteLine("Conexion exitosa a SQL Server");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problema al tratar de conectar a BD. Detalles:");
                Console.WriteLine(ex.Message);
            }
        }

        private static void MostrarDatosDeEmpleado()
        {
            try
            {
                string sqlQuery = "SELECT * FROM Empleado";
                mySqlCommand = new SqlCommand(sqlQuery,conexion);
                mySqlDataReader = mySqlCommand.ExecuteReader();
                Console.WriteLine("Empleado Id\t\t Nombre\t\t Edad\t\t Salario");
                Console.WriteLine("___________________________________");
                while(mySqlDataReader.Read())
                {
                    Console.WriteLine($"{mySqlDataReader["Id"]}\t\t {mySqlDataReader["Nombre"]}\t\t {mySqlDataReader["Edad"]}\t\t {mySqlDataReader["Salario"]}");
                }
                mySqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problema al tratar de conectar a BD. Detalles:");
                Console.WriteLine(ex.Message);
            }
        }

        private static void InsertarNuevoEmpleado(string nombre, byte edad, decimal salario)
        {
            try
            {
                string sqlQuery = "INSERT INTO Empleado(Nombre,Edad,Salario) VALUES (@nombre,@edad,@salario)";
                mySqlCommand = new SqlCommand(sqlQuery, conexion);
                mySqlCommand.Parameters.AddWithValue("nombre", nombre);
                mySqlCommand.Parameters.AddWithValue("edad", edad);
                mySqlCommand.Parameters.AddWithValue("salario", salario);
                int resultado = mySqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{resultado} Registro insertado correctamente");
                Console.WriteLine("Datos actuales de la tabla");
                MostrarDatosDeEmpleado();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problema al tratar de conectar a BD. Detalles:");
                Console.WriteLine(ex.Message);
            }
        }

        private static void ActualizarEmpleado(string nombre, decimal aumento)
        {
            try
            {
                Console.WriteLine($"Actualizar salario del empleado {nombre}");
                string sqlQuery = "UPDATE Empleado SET Salario = @salario WHERE Nombre = @nombre";

                mySqlCommand = new SqlCommand(sqlQuery, conexion);
                mySqlCommand.Parameters.AddWithValue("salario", aumento);
                mySqlCommand.Parameters.AddWithValue("nombre", nombre);
                int resultado = mySqlCommand.ExecuteNonQuery();

                Console.WriteLine($"{resultado} Registro se actualizo en la Base de datos");
                Console.WriteLine($"{nombre} ahora tiene un aumento de {aumento}");
                Console.WriteLine("Datos actuales de la base de datos");
                MostrarDatosDeEmpleado();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problema al tratar de conectar a BD. Detalles:");
                Console.WriteLine(ex.Message);
            }
        }

        private static void EliminarEmpleado()
        {
            try
            {
                Console.WriteLine("Ingresa el nombre del empleado a Eliminar");
                string empleadoEliminar = Console.ReadLine();
                string sqlQuery = "DELETE FROM Empleado WHERE Nombre = @nombre";

                mySqlCommand = new SqlCommand(sqlQuery, conexion);
                mySqlCommand.Parameters.AddWithValue("nombre", empleadoEliminar);
                int resultado = mySqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{resultado} Registro eliminado correctamente");
                Console.WriteLine("Datos actuales de la tabla");
                MostrarDatosDeEmpleado();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problema al tratar de conectar a BD. Detalles:");
                Console.WriteLine(ex.Message);
            }
        }
        private static void CerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problema al tratar de conectar a BD. Detalles:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
