﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace compesa.Models
{
    [Keyless]
    public class GetOcorrencia
    {

        public int? Id_Ocorrencia { get; set; }
        public int? Id_criador { get; set; }
        public string? Criador { get; set; } = string.Empty;

        public bool? Has_Reducao_Vazao { get; set; }
        public string? Atualizado_por { get; set; } = string.Empty;
        public string? Unidade { get; set; } = string.Empty;
        public string? Tipo { get; set; } = string.Empty;
        public DateTime? Data { get; set; }
        public Boolean? Estado { get; set; }
        public int? Comunicado { get; set; }
        public int? Prot_neoenergia { get; set; }
        public int? Pm_alpha { get; set; }
        public Boolean? EstadoParado { get; set; }
        public string? Descricao { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

    }
}
