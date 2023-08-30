using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MD5Hash;


namespace CapaDeDatos
{
    public class UserModel : Model
    {

        public string Username;
        public string Password;

        private int id;
        private string tipo;

        public void Save()
        {
            this.Command.CommandText = 
                $"INSERT INTO User(username,password) " +
                $"VALUES ('{this.Username}','{Hash.Content(this.Password)}')";

            this.Command.ExecuteNonQuery();
        }

        public Dictionary<string,string> Login()
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();

            this.Command.CommandText = $"SELECT id, username, password, tipo " +
                $"From User where username = '{this.Username}'";
            this.Reader = this.Command.ExecuteReader();

            if (this.Reader.HasRows)
            {
                this.Reader.Read();
                string dbPassword = this.Reader["password"].ToString();

                if (Hash.Content(this.Password) == dbPassword)
                {
                    resultado.Add("resultado", "OK");
                    resultado.Add("tipo", this.Reader["tipo"].ToString());
                    return resultado;
                }
                    
            }
            resultado.Add("resultado", "Error");

            return resultado;

        }
    }
}
