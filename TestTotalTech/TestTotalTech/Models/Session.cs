
using Xamarin.Forms;

namespace TestTotalTech.Models
{
    public class Session
    {
        #region variables privadas
        private string user;
        private string password;
        private string token;
        #endregion

        #region propiedades

        public string User
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(cs.user))
                {
                    user = Application.Current.Properties[cs.user] as string;
                }
                return user;
            }
            set
            {
                user = value;
                Application.Current.Properties[cs.user] = user;
            }
        }

        public string Password
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(cs.password))
                {
                    password = Application.Current.Properties[cs.password] as string;
                }
                return password;
            }
            set
            {
                password = value;
                Application.Current.Properties[cs.password] = password;
            }
        }

        public string Token
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(cs.token))
                {
                    token = Application.Current.Properties[cs.token] as string;
                }
                return token;
            }
            set
            {
                token = value;
                Application.Current.Properties[cs.token] = token;
            }
        }

        #endregion

        #region cerrar sesion
        public void ClearSession()
        {
            try
            {
                this.User = null;
                this.Password = null;
                this.Token = null;
                Application.Current.Properties.Clear();
            }
            catch
            { }
        }
        #endregion
    }

    #region constantes
    internal class cs
    {
        public const string user = "user";
        public const string password = "password";
        public const string token = "token";
    }
    #endregion
}

