using Microsoft.EntityFrameworkCore;

namespace compesa.Models
{
    [Keyless]
    public class UnidadeQuant
    {
        public string? Nome_Unidade { get; set; } = string.Empty;
        public int? Total { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? Total_Parada { get; set; }
        public int? Total_Reducao_Vazao { get; set; }
    }
}
