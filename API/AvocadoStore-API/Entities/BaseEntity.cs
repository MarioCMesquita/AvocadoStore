using System;

namespace AvocadoStore_API.Entities
{
    public class BaseEntity
    {
        public int Cd_user_delete { get; set; }
        public DateTime Dt_delete { get; set; }
        public int Cd_user { get; set; }
    }
}
