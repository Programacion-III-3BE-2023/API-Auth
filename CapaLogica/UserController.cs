using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaLogica
{
    public static class UserController
    {
        public static void Crear(string username, string password)
        {
            UserModel user = new UserModel();
            user.Username = username;
            user.Password = password;
            user.Save();
        }

        public static Dictionary<string,string> Login(string username, string password)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            resultado = Auth.Login(username, password);
            return resultado;

               
        }
    }
}
