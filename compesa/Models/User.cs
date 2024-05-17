
using Microsoft.EntityFrameworkCore;

namespace compesa.Models
{
    [Keyless]
    public class User
    {
        public int ID_Usuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha {  get; set; } = string.Empty;
        
    }
}
