using Microsoft.EntityFrameworkCore;

namespace compesa.Models
{
    [Keyless]
    public class UserPermissions
    {
        public string Nome { get; set; } = string.Empty;
    }
}
