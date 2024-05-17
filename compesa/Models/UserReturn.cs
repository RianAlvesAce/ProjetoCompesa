namespace compesa.Models
{
    public class UserReturn
    {
        public int User_Id { get; set; }
        public string name { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = new();
    }
}
