namespace Operations.Users
{
    public class RegisterUserDto
    {
        public string username { get; set; } = "";
        public string password {get; set;} = "";
        public int id_rol { get; set; }
    }
}