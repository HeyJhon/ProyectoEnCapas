using System;
using ML;
using DAL;
using System.Collections.Generic;

namespace BL
{
    public class EmpleadoBL
    {
        EmpleadoADO contexto;
        public EmpleadoBL()
        {
            contexto = new EmpleadoADO();
        }

        public List<Empleado> GetEmpleados()
        {
            return contexto.GetEmpleados();
        }
    }
}
