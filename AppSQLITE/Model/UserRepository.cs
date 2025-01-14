using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppSQLITE.Model
{
    public class UserRepository
    {
        #region Attributos
        private SQLiteConnection con;
        private static UserRepository instance;
        private string estadoMensaje;
        #endregion

        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                    throw new Exception("Debe llamar al metodo inicializador");
                return instance;
            }
        }

        public static void Inicializador(string filename)
        {
            if (filename == null) throw new ArgumentNullException("filename");

            if (instance != null)
                instance.con.Close();

            instance = new UserRepository(filename);
        }

        private UserRepository(string dbpath)
        {
            con = new SQLiteConnection(dbpath);
            con.CreateTable<User>();
        }

        public int AddUser(string username, string email, string password)
        {
            int result = 0;
            try
            {
                result = con.Insert(new User()
                {
                    UserName = username,
                    Email = email,
                    Password = password
                });

                estadoMensaje = string.Format("Cantidad de filas afectadas {0}", result);
            }
            catch (Exception ex)
            {
                estadoMensaje = ex.Message;
            }

            return result;
        }

        public IEnumerable<User> getUsers()
        {
            try
            {
                return con.Table<User>();
            }
            catch (Exception ex)
            {
                estadoMensaje = ex.Message;
            }
            return Enumerable.Empty<User>();
        }
    }
}

