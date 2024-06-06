using compesa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

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

        [HttpGet("GetUnidadeCount")]
        public IActionResult getUnidadeCount()
        {
            var unidades = _dataContext.unidadeQuants.FromSqlRaw("\nSELECT unidade.Nome_Unidade, COUNT(ocorrencia.ID_Ocorrencia) AS Total, COALESCE(SUM(Has_Parada = 1), 0) AS Total_Parada, COALESCE(SUM(Has_Reducao_vazao = 1), 0) AS Total_Reducao_Vazao, unidade.Latitude, unidade.Longitude\nFROM unidade\nLEFT JOIN ocorrencia ON unidade.ID_Unidade = ocorrencia.ID_Unidade\nGROUP BY unidade.Nome_Unidade;").ToList();
            return Ok(unidades);
        }

        [HttpGet("getOcorrencias")]
        public IActionResult getOcorrencias()
        {
            var ocorrencias = _dataContext.Ocorrencias.FromSqlRaw("SELECT usuario.nome AS 'criador', unidade.Nome_Unidade AS 'unidade', ID_Ocorrencia AS 'id_ocorrencia', ocorrencia.ID_Usuario AS 'id_criador', tipo.nome AS 'tipo', Data_Criacao AS 'data', aberta AS 'estado', Relato_Sic AS 'descricao', Has_Parada AS 'estadoParado', Comunicado_Sic AS 'comunicado', Pm_Alpha AS 'pm_alpha', Autor_Ultima_Edicao as 'atualizado_por', Prot_Energia AS 'prot_neoenergia', ocorrencia.Latitude, ocorrencia.Longitude, Has_Reducao_Vazao FROM ocorrencia JOIN usuario ON ocorrencia.ID_Usuario = usuario.ID_Usuario JOIN unidade ON ocorrencia.ID_Unidade = unidade.ID_Unidade JOIN tipo ON ocorrencia.ID_Tipo = tipo.ID_Tipo;").ToList();
            return Ok(ocorrencias);
        }

        [HttpPost("postOcorrencia")]
        public async Task<IActionResult> postOcorrencia(Ocorrencia ocorrencia)
        {

            _dataContext.ocorrencia.Add(ocorrencia);
            await _dataContext.SaveChangesAsync();

            return Ok(new {msg = "foi"});

        }

        [HttpGet("getUnidades")]
        public IActionResult getUnidades()
        {
            var unidades = _dataContext.Unidades.FromSqlRaw("SELECT ID_Unidade, Nome_Unidade AS 'nome_unidade', Endereco_Unidade AS 'endereco', Latitude, Longitude FROM unidade").ToList();

            List <Unidade> unidadesList = new();

            foreach (var unidade in unidades)
            {
                Unidade uni = new Unidade(endereco: unidade.endereco, Nome_unidade: unidade.Nome_unidade, latitude: unidade.latitude, longitude: unidade.longitude, ID_Unidade: unidade.ID_Unidade);
                unidadesList.Add(uni);
            }
            return Ok(unidadesList);
        }

        [HttpGet("getTipos")]
        public IActionResult getTipos()
        {
            var tipos = _dataContext.Tipos.FromSqlRaw("SELECT Id_Tipo AS 'id', Nome AS 'name' FROM tipo").ToList();

            return Ok(tipos);
        }
    }
}
