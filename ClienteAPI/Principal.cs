using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;

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

        private void Principal_Load(object sender, EventArgs e)
        {

            RestClient client = new RestClient("http://localhost:49923");
            RestRequest request = new RestRequest("/api/login", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            RestResponse response = client.Execute(request);

            // Mandar al datagridview :)


        }
    }
}
