using AvocadoStore_API.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using AvocadoStore_API.Utils;

namespace AvocadoStore_API.Repository
{
    public class LoginRepository : BaseRepository
    {
        public UserEntity Login(string login, string password)
        {
            try
            {
                var hashPass = new Utilities().GenerateHash(login, password);

                string query = $@"SELECT * FROM Users
                                  WHERE ST_LOGIN = '{login}'
                                  AND ST_PASSWORD = '{hashPass}'
                                  AND DT_DELETE IS NULL";

                UserEntity user = new UserEntity();
                DataTable result = ExecQuery(query);

                if (result.Rows.Count == 0)
                    return null;

                user = new UserEntity()
                {
                    Cd_usuario = Convert.ToInt32(result.Rows[0]["CD_USUARIO"]),
                    St_name = Convert.ToString(result.Rows[0]["ST_NAME"]),
                    St_email = Convert.ToString(result.Rows[0]["ST_EMAIL"]),
                    St_role = Convert.ToString(result.Rows[0]["ST_ROLE"]),
                    St_login = Convert.ToString(result.Rows[0]["ST_LOGIN"]),
                    St_password = Convert.ToString(result.Rows[0]["ST_PASSWORD"])
                };

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
