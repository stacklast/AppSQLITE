using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppSQLITE.Model
{
    public class UserRepository
    {
        #region Attributos
        private readonly SQLiteConnection _con;
        private static UserRepository _instance;
        public string estadoMensaje;
        #endregion

        public static UserRepository Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception("Debe llamar al metodo inicializador");
                return _instance;
            }
        }

        public static void Inicializador(string filename)
        {
            if (filename == null) throw new ArgumentNullException("filename");

            if (_instance != null)
                _instance._con.Close();

            _instance = new UserRepository(filename);
        }

        private UserRepository(string dbpath)
        {
            _con = new SQLiteConnection(dbpath);
            _con.CreateTable<User>();
        }

        public int AddUser(string username, string email, string password)
        {
            int result = 0;
            try
            {
                result = _con.Insert(new User()
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

        public IEnumerable<User> GetUsers()
        {
            try
            {
                return _con.Table<User>();
            }
            catch (Exception ex)
            {
                estadoMensaje = ex.Message;
            }
            return Enumerable.Empty<User>();
        }

        public int UpdateUser(User user)
        {
            int result = 0;
            try
            {
                result = _con.Update(user);
                estadoMensaje = string.Format("Cantidad de filas afectadas {0}", result);
            }
            catch (Exception ex)
            {
                estadoMensaje = ex.Message;
            }

            return result;
        }
        public int DeleteUser(int id)
        {
            int result = 0;
            try
            {
                result = _con.Delete<User>(id);
                estadoMensaje = string.Format("Cantidad de filas afectadas {0}", result);
            }
            catch (Exception ex)
            {
                estadoMensaje = ex.Message;
            }

            return result;
        }
    }
}

