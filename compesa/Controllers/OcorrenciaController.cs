using compesa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace compesa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciaController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public OcorrenciaController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpGet("getOcorrencias")]
        public IActionResult getOcorrencias()
        {
            var ocorrencias = _dataContext.Ocorrencias.FromSqlRaw("SELECT usuario.nome AS 'criador', unidade.Nome_Unidade AS 'unidade', ID_Ocorrencia AS 'id_ocorrencia', ocorrencia.ID_Usuario AS 'id_criador', tipo.nome AS 'tipo', Data_Criacao AS 'data', aberta AS 'estado', relato AS 'descricao', Has_Parada AS 'estadoParado', Comunicado_Sic AS 'comunicado', Pm_Alpha AS 'pm_alpha', Autor_Ultima_Edicao as 'atualizado_por', Prot_Energia AS 'prot_neoenergia' FROM ocorrencia JOIN usuario ON ocorrencia.ID_Usuario = usuario.ID_Usuario JOIN unidade ON ocorrencia.ID_Unidade = unidade.ID_Unidade JOIN tipo ON ocorrencia.ID_Tipo = tipo.ID_Tipo;").ToList();
            return Ok(ocorrencias);
        }

        [HttpPost("postOcorrencia")]
        public IActionResult postOcorrencia(Ocorrencia ocorrencia)
        {


            return Ok();

        }

        [HttpGet("getUnidades")]
        public IActionResult getUnidades()
        {
            var unidades = _dataContext.Unidades.FromSqlRaw("SELECT Nome_Unidade AS 'nome_unidade' FROM unidade").ToList();

            List<string> unidadesList = new();

            foreach (var unidade in unidades)
            {
                unidadesList.Add(unidade.Nome_unidade);
            }
            return Ok(unidadesList);
        }
    }
}
