using System;

namespace ML
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte Edad { get; set; }
        public decimal Salario { get; set; }

        public Empleado()
        {

        }

        public Empleado(int id, string nombre, byte edad, decimal salario)
        {
            Id = id;
            Nombre = nombre;
            Edad = edad;
            Salario = salario;
        }
    }
}
