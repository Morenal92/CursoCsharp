using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_app
{
    public partial class frmDiscos : Form
    {
        public frmDiscos()
        {
            InitializeComponent();
        }

        private void frmDiscos_Load(object sender, EventArgs e)
        {
            // aca voy a acceder a mis datos para mostrarlos en la grilla
            DiscoNegocio negocio = new DiscoNegocio();
            // va a la base de datos y me devuelve una lista de datos y los modela en la tabla
            dgvDiscos.DataSource = negocio.listar();
        }
    }
}
