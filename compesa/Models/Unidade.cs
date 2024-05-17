using Microsoft.EntityFrameworkCore;

namespace compesa.Models
{
    [Keyless]
    public class Unidade
    {
        public string Nome_unidade { get; set; } = string.Empty;
    }
}
