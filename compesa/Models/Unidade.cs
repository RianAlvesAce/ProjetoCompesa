using Microsoft.EntityFrameworkCore;

namespace compesa.Models
{
    [Keyless]
    public class Unidade
    {
            
        public Unidade(string endereco, string Nome_unidade, double latitude, double longitude, int ID_Unidade) {
            this.endereco = endereco;
            this.Nome_unidade = Nome_unidade;
            this.latitude = latitude;
            this.longitude = longitude;
            this.ID_Unidade = ID_Unidade;
        }

        public string Nome_unidade { get; set; } = string.Empty;
        public string endereco { get; set; } = string.Empty;
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int ID_Unidade { get; set; }
    }
}
