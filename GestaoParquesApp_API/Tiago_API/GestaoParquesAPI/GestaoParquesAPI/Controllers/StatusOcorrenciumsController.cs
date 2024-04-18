using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoParquesAPI.Models;
using GestaoParquesAPI.DTOs;

namespace GestaoParquesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusOcorrenciumsController : ControllerBase
    {
        private readonly GestaoParquesContext _context;

        public StatusOcorrenciumsController(GestaoParquesContext context)
        {
            _context = context;
        }

        // GET: api/StatusOcorrenciums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusOcorrenciaDTO>>> GetStatusOcorrencia()
        {
            var statusOcorrencia = await _context.StatusOcorrencia.ToListAsync();

            var statusOcorrenciaDTO = statusOcorrencia.Select(s => new StatusOcorrenciaDTO().StatusOcorrenciaModelToDto(s)).ToList();

            return statusOcorrenciaDTO;
        }

        // GET: api/StatusOcorrenciums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusOcorrenciaDTO>> GetStatusOcorrencium(int id)
        {
            var statusOcorrencium = await _context.StatusOcorrencia.FindAsync(id);

            if (statusOcorrencium == null)
            {
                return NotFound();
            }

            // Converte o TipoOcorrencium para TipoOcorrenciaDTO
            var statusOcorrenciaDTO = new StatusOcorrenciaDTO().StatusOcorrenciaModelToDto(statusOcorrencium);

            return statusOcorrenciaDTO;
        }

        // PUT: api/StatusOcorrenciums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusOcorrencium(int id, StatusOcorrenciaDTO statusOcorrenciaDTO)
        {
            if (id != statusOcorrenciaDTO.IdStatusOcorrencia)
            {
                return BadRequest();
            }

            // Buscar o StatusOcorrencium no banco de dados com base no id fornecido
            var statusOcorrencium = await _context.StatusOcorrencia.FindAsync(id);

            // Verificar se o StatusOcorrencium foi encontrado
            if (statusOcorrencium == null)
            {
                return NotFound();
            }

            // Atualizar apenas as propriedades necessárias com base nos dados do DTO
            statusOcorrencium.DescricaoStatus = statusOcorrenciaDTO.DescricaoStatus;
            // Definir outras atualizações, se necessário

            try
            {
                // Salvar as alterações no banco de dados
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusOcorrenciumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/StatusOcorrenciums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusOcorrencium>> PostStatusOcorrencium(StatusOcorrenciaDTO statusOcorrenciaDTO)
        {
            // Convertendo o DTO para o modelo StatusOcorrencium
            StatusOcorrencium statusOcorrencium = statusOcorrenciaDTO.DtoToStatusOcorrenciaModel();

            // Adicionando o status de ocorrência ao contexto do banco de dados
            _context.StatusOcorrencia.Add(statusOcorrencium);
            await _context.SaveChangesAsync();

            // Retorna um resultado CreatedAtAction com o DTO do status de ocorrência recém-criado
            StatusOcorrenciaDTO novoStatusOcorrenciaDTO = new StatusOcorrenciaDTO().StatusOcorrenciaModelToDto(statusOcorrencium);
            return CreatedAtAction("GetStatusOcorrencium", new { id = novoStatusOcorrenciaDTO.IdStatusOcorrencia }, novoStatusOcorrenciaDTO);
        }


        // DELETE: api/StatusOcorrenciums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusOcorrencium(int id)
        {
            var statusOcorrencium = await _context.StatusOcorrencia.FindAsync(id);
            if (statusOcorrencium == null)
            {
                return NotFound();
            }

            // Verifica se existem ocorrências associadas ao status de ocorrência
            var ocorrenciasAssociadas = await _context.HistoricoOcorrencia.AnyAsync(o => o.IdStatusOcorrencia == id);
            if (ocorrenciasAssociadas)
            {
                // Se existirem ocorrências associadas, retorna um erro informando que a exclusão não é permitida
                return BadRequest("Não é possível excluir este status de ocorrência pois existem ocorrências associadas a ele.");
            }

            _context.StatusOcorrencia.Remove(statusOcorrencium);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool StatusOcorrenciumExists(int id)
        {
            return _context.StatusOcorrencia.Any(e => e.IdStatusOcorrencia == id);
        }
    }
}
