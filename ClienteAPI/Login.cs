﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.IO;
using RestSharp;

namespace ClienteAPI
{
    public class ResultadoLogin
    {
        public int Id;
        public string Username;
        public string Tipo;
        public string Resultado;
    }

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private ResultadoLogin deserializar(string content)
        {
            return JsonConvert.DeserializeObject<ResultadoLogin>(content);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            Dictionary<string, string> requestBody = new Dictionary<string, string>(){
                { "username", txtUsername.Text },
                { "password", txtPassword.Text }
            };
            string requestBodyString = JsonConvert.SerializeObject(requestBody);

            RestClient client = new RestClient("http://localhost:49923");

            RestRequest request = new RestRequest("/api/login", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(requestBodyString);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            RestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                MessageBox.Show("Login Invalido");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ResultadoLogin resultado = this.deserializar(response.Content);
                MessageBox.Show(resultado.Tipo);
            }
        }
    }
}