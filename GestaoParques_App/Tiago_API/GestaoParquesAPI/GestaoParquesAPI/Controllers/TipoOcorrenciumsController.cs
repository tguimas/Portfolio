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
    public class TipoOcorrenciumsController : ControllerBase
    {
        private readonly GestaoParquesContext _context;

        public TipoOcorrenciumsController(GestaoParquesContext context)
        {
            _context = context;
        }

        // GET: api/TipoOcorrenciums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoOcorrenciaDTO>>> GetTipoOcorrencia()
        {
            var tipoOcorrencia = await _context.TipoOcorrencia.ToListAsync();

            var tipoOcorrenciaDTO = tipoOcorrencia.Select(o => new TipoOcorrenciaDTO().TipoOcorrenciaModelToDto(o)).ToList();


            return tipoOcorrenciaDTO;
        }

        // GET: api/TipoOcorrenciums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoOcorrenciaDTO>> GetTipoOcorrencium(int id)
        {
            var tipoOcorrencium = await _context.TipoOcorrencia.FindAsync(id);

            if (tipoOcorrencium == null)
            {
                return NotFound();
            }

            // Converte o TipoOcorrencium para TipoOcorrenciaDTO
            var tipoOcorrenciaDTO = new TipoOcorrenciaDTO().TipoOcorrenciaModelToDto(tipoOcorrencium);

            return tipoOcorrenciaDTO;
        }


        // PUT: api/TipoOcorrenciums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoOcorrencium(int id, TipoOcorrenciaDTO tipoOcorrenciaDTO)
        {
            if (id != tipoOcorrenciaDTO.IdTipoOcorrencia)
            {
                return BadRequest();
            }

            // Buscar o TipoOcorrencium no banco de dados com base no id fornecido
            var tipoOcorrencium = await _context.TipoOcorrencia.FindAsync(id);

            // Verificar se o TipoOcorrencium foi encontrado
            if (tipoOcorrencium == null)
            {
                return NotFound();
            }

            // Atualizar apenas as propriedades necessárias com base nos dados do DTO
            tipoOcorrencium.NomeTipoOcorrencia = tipoOcorrenciaDTO.NomeTipoOcorrencia;

            try
            {
                // Salvar as alterações no banco de dados
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoOcorrenciumExists(id))
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


        // POST: api/TipoOcorrenciums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoOcorrencium>> PostTipoOcorrencium(TipoOcorrenciaDTO tipoOcorrenciaDTO)
        {
            // Convertendo o DTO para o modelo TipoOcorrencium
            TipoOcorrencium tipoOcorrencium = tipoOcorrenciaDTO.DtoToTipocorrenciaModel();

            // Adicionando o tipo de ocorrência ao contexto do banco de dados
            _context.TipoOcorrencia.Add(tipoOcorrencium);
            await _context.SaveChangesAsync();

            // Retorna um resultado CreatedAtAction com o DTO do tipo de ocorrência recém-criado
            TipoOcorrenciaDTO novoTipoOcorrenciaDTO = new TipoOcorrenciaDTO().TipoOcorrenciaModelToDto(tipoOcorrencium);
            return CreatedAtAction("GetTipoOcorrencium", new { id = novoTipoOcorrenciaDTO.IdTipoOcorrencia }, novoTipoOcorrenciaDTO);
        }


        // DELETE: api/TipoOcorrenciums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoOcorrencium(int id)
        {
            // Busca o tipo de ocorrência no banco de dados com base no ID fornecido
            var tipoOcorrencia = await _context.TipoOcorrencia.FindAsync(id);
            if (tipoOcorrencia == null)
            {
                return NotFound();
            }

            // Verifica se existem ocorrências associadas ao tipo de ocorrência
            var ocorrenciasAssociadas = await _context.Ocorrencia.AnyAsync(o => o.IdTipoOcorrencia == id);
            if (ocorrenciasAssociadas)
            {
                // Se existirem ocorrências associadas, retorna um erro informando que a exclusão não é permitida
                return BadRequest("Não é possível excluir este tipo de ocorrência pois existem ocorrências associadas a ele.");
            }

            // Remove o tipo de ocorrência do contexto do banco de dados
            _context.TipoOcorrencia.Remove(tipoOcorrencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }





        private bool TipoOcorrenciumExists(int id)
        {
            return _context.TipoOcorrencia.Any(e => e.IdTipoOcorrencia == id);
        }
    }
}
