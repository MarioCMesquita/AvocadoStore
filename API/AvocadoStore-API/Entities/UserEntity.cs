namespace AvocadoStore_API.Entities
{
    public class UserEntity : BaseEntity
    {
        public int Cd_usuario { get; set; }
        public string St_name { get; set; }
        public string St_email { get; set; }
        public string St_login { get; set; }
        public string St_password { get; set; }
        public string? St_role { get; set; }
    }
}
