using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML;
using BL;
namespace WindowsFormsCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EmpleadoBL contexto = new EmpleadoBL();
            List<Empleado> lista = contexto.GetEmpleados();

            listBox1.DataSource = lista;
            listBox1.DisplayMember = "Nombre";
            listBox1.ValueMember = "Id";
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            Empleado empleadoSelect = (Empleado)listBox1.SelectedItem;
            MessageBox.Show($"El salario del empleado {empleadoSelect.Nombre} es {empleadoSelect.Salario}");
        }
    }
}
