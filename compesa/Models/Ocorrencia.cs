using System.ComponentModel.DataAnnotations;

namespace compesa.Models
{

    public class Ocorrencia
    {

        [Key]
        public int Id_Ocorrencia { get; set; }

        public int ID_Usuario { get; set; }
        public int ID_Unidade { get; set; }

        public int ID_Tipo { get; set; }
        public int Prot_Energia { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Relato_Sic { get; set; } = string.Empty;
        public string Comunicado_Sic { get; set; } = string.Empty;
        public string Relato_Abertura { get; set; } = string.Empty;
        public string Tipo_Falta { get; set; } = string.Empty;
        public string Hora_Ocorrencia { get; set; } = string.Empty;
        public string Hora_Prevista { get; set; } = string.Empty;
        public string Autor_Abertura { get; set; } = string.Empty;
        public string Autor_Ultima_Edicao { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public Boolean Has_Parada { get; set; }
        public Boolean Falta_Energia { get; set; }
        public Boolean Aberta { get; set; }
        public DateTime Data_Ultima_Edicao { get; set; }
        public DateTime Data_Criacao { get; set; }
        public DateTime Inicio_Previsto { get; set; }
        public DateTime Termino_Previsto { get; set; }

    }
}
