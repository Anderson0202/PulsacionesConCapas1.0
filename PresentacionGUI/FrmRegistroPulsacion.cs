using BLL;
using Entity;
using System;
using System.Windows.Forms;
namespace PresentacionGUI
{
    public partial class FrmRegistroPulsacion : Form
    {

        private readonly PersonaService servicePersona;

        public FrmRegistroPulsacion()
        {
            InitializeComponent();
            servicePersona = new PersonaService();
            CmbSexo.Items.Add("SELECCIONE");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private bool LimpiarTexto()
        {
            foreach (Control itemControl in this.Controls)
            {
                if (itemControl is TextBox || itemControl is ComboBox)
                {
                    itemControl.Text = "";
                }
            }
            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            LimpiarTexto();
        }

        private void Guardar()
        {

            

        }

        private Persona MapearElTexto_Persona()
        {

            var persona = new Persona();
            persona.Identificacion = TxtIdentificacion.Text;
            persona.Nombre = TxtNombre.Text;
            persona.Edad = Convert.ToInt32(TxtEdad.Text);
            do
            {
                if (CmbSexo.Items.Equals("SELECCIONE"))
                {
                    MessageBox.Show("SELECCIONE EL SEXO");
                    CmbSexo.Focus();
                }
                else
                {
                    persona.Sexo = Convert.ToString(CmbSexo.Text);
                }

            } while (CmbSexo.Items.Equals("SELECCIONE"));

            persona.Pulsacion = servicePersona.CalcularPulsacion(persona.Sexo, persona.Edad);
            MessageBox.Show(servicePersona.guardar(persona));
            LblPulsacion.Text = Convert.ToString(persona.Pulsacion);
            
            return persona;

        }

        private void MapearLaPersona_Texto(Persona persona)
        {

            TxtIdentificacion.Text = persona.Identificacion;
            TxtNombre.Text = persona.Nombre;
            TxtEdad.Text = persona.Edad.ToString();
            CmbSexo.Text = persona.Sexo;
            LblPulsacion.Text = persona.Pulsacion.ToString();

        }


        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {

            servicePersona.BuscarConIdentificacion(TxtIdentificacion.Text);

        }



    }
}
