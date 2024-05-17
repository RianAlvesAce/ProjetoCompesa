using Microsoft.EntityFrameworkCore;

namespace compesa.Models
{
    [Keyless]
    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
