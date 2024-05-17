using Microsoft.EntityFrameworkCore;

namespace compesa.Models
{
    [Keyless]
    public class UserMod
    {
        public int ID_Usuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Id_user { get; set; }
        public int Id_module { get; set; }
        public string Mod_Name { get; set; } = string.Empty;

    }
}
