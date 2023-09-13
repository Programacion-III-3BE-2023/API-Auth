using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteAPI
{
    public partial class Principal : Form
    {
        public void GetResultado(JsonResponses.ResultadoLogin data)
        {
            lblId.Text = data.Id.ToString();
            lblResultado.Text = data.Resultado;
            lblTipo.Text = data.Tipo;
            lblUsername.Text = data.Username;
        }

        public Principal()
        {
            InitializeComponent();
        }
    }
}
