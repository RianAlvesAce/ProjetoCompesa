using Microsoft.EntityFrameworkCore;

namespace compesa.Models
{
    [Keyless]
    public class LigModUser
    {
        public int Id_User { get; set; }
        public int Id_Module { get; set; }
    }
}
