using AvocadoStore_API.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using AvocadoStore_API.Utils;

namespace AvocadoStore_API.Repository
{
    public class UserRepository : BaseRepository
    {
        public void Save(UserEntity entity)
        {
            try
            {
                var passHash = new Utilities().GenerateHash(entity.St_login, entity.St_password);

                string query = $@"INSERT INTO Users
                                  VALUES (
	                                  '{entity.St_name}',
	                                  '{entity.St_email}',
	                                  '{entity.St_role}',
	                                  '{entity.St_login}',
	                                  '{passHash}',
	                                  null,
	                                  null
                                  )";

                ExecCommand(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(UserEntity entity)
        {
            try
            {
                var passHash = new Utilities().GenerateHash(entity.St_login, entity.St_password);

                string query = $@"UPDATE Users
                                  SET ST_NAME = '{entity.St_name}',
	                                  ST_EMAIL = '{entity.St_email}',
                                      ST_ROLE = '{entity.St_role}',
	                                  ST_LOGIN = '{entity.St_login}',
	                                  ST_PASSWORD = '{passHash}'
                                  WHERE CD_USUARIO = {entity.Cd_usuario}";

                ExecCommand(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id, int cd_user)
        {
            try
            {
                string query = $@"UPDATE Users
                                  SET CD_USER_DELETE = {cd_user},
                                      DT_DELETE = GETDATE()
                                  WHERE CD_USUARIO = {id}";

                ExecCommand(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserEntity GetById(int id)
        {
            try
            {
                string query = $@"SELECT * FROM Users WHERE CD_USUARIO = {id} AND DT_DELETE IS NULL";

                UserEntity user = new UserEntity();
                DataTable result = ExecQuery(query);

                user = new UserEntity()
                {
                    Cd_usuario = Convert.ToInt32(result.Rows[0]["CD_USUARIO"]),
                    St_name = Convert.ToString(result.Rows[0]["ST_NAME"]),
                    St_email = Convert.ToString(result.Rows[0]["ST_EMAIL"]),
                    St_role = Convert.ToString(result.Rows[0]["ST_ROLE"]),
                    St_login = Convert.ToString(result.Rows[0]["ST_LOGIN"]),
                    St_password = Convert.ToString(result.Rows[0]["ST_PASSWORD"])
                };

                if (result.Rows.Count == 0)
                    return null;

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserEntity> GetAll()
        {
            try
            {
                string query = $@"SELECT * FROM Users WHERE DT_DELETE IS NULL";

                List<UserEntity> userList = new List<UserEntity>();
                DataTable result = ExecQuery(query);

                foreach (DataRow row in result.Rows)
                {
                    userList.Add(new UserEntity()
                    {
                        Cd_usuario = Convert.ToInt32(row["CD_USUARIO"]),
                        St_name = Convert.ToString(row["ST_NAME"]),
                        St_email = Convert.ToString(row["ST_EMAIL"]),
                        St_role = Convert.ToString(row["ST_ROLE"]),
                        St_login = Convert.ToString(row["ST_LOGIN"]),
                        St_password = Convert.ToString(row["ST_PASSWORD"])
                    });
                }

                if (result.Rows.Count == 0)
                    return null;

                return userList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
