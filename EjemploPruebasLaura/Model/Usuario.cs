using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EjemploPruebasLaura.Model
{
    public class Usuario
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool activo { get; set; }

        public Usuario()
        {
            username = "admin";
            password = "aaa111...";
            activo = true;
            
        }

        /// <summary>
        /// Constructor de usuario, uso el nombre del usuario o la contraseña. Si estan vacias se asigna la constraseña por defecto.
        /// </summary>
        /// <param name="user">Nombre del usuario</param>
        /// <param name="pass">Contraseña sin cifrar</param>
        public Usuario(string user, string pass)
        {
            if (user == null || user.Length == 0)
                user = "admin";
            username = user;
            if (pass == null || pass.Length == 0)
                pass = "aaa111...";
            password = pass;
            activo = true;
        }

        public override string ToString()
        {
            return this.username + ";" + this.password;

        }

        public string getMD5(string pass)
        {

                if (pass == null || pass.Length == 0) return null;
                MD5 md5 = MD5CryptoServiceProvider.Create();
                ASCIIEncoding en = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = md5.ComputeHash(en.GetBytes(pass));
                for (int i = 0; i < stream.Length; i++)
                {
                    sb.AppendFormat("{0:x2}", stream[i]);
                }
                return sb.ToString();

        }
    }
}