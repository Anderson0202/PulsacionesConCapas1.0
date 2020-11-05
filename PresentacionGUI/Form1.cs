using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;
namespace PresentacionGUI
{
    public partial class Form1 : Form
    {
        
        PersonaService service;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {

            Persona persona = new Persona();
            persona.Identificacion = TxtIdentificacion.Text;
            persona.Nombre = TxtNombre.Text;
            persona.Edad = Convert.ToInt32(TxtEdad.Text);
            if (CmbSexo.Items.Equals("SELECCIONE"))
            {
                MessageBox.Show("SELECCIONE EL SEXO");
            }
            else
            {
            persona.Sexo = Convert.ToString(CmbSexo.Text);
            }
            service = new PersonaService();
            persona.Pulsacion = service.CalcularPulsacion(persona.Sexo, persona.Edad);
            LblPulsacion.Text = Convert.ToString(persona.Pulsacion);
            MessageBox.Show(service.guardar(persona));

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            
            service.BuscarConIdentificacion(TxtIdentificacion.Text);
            

        }
    }
}
