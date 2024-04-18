using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoParquesAPI.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using GestaoParquesAPI.DTOs;

namespace GestaoParquesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncaoController : ControllerBase
    {
        private readonly GestaoParquesContext _context;

        public FuncaoController(GestaoParquesContext context)
        {
            _context = context;
        }

        // GET: api/Funcao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncaoDTO>>> GetFuncaos() // foi mudado de Funcao para FuncaoDTO, chama a classe.
        {
            // Consulta o banco de dados para obter todas as Funcoes, incluindo os Users relacionados
            var funcoes = await _context.Funcaos.Include(f => f.Users).ToListAsync();

            // retornando so o id dos objetos users já tratados na classe FuncaoDTO
            var funcoesDTO = funcoes.Select(f => new FuncaoDTO().FuncaoModelToDto(f)).ToList();

            return funcoesDTO;
        }


        // GET: api/Funcao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FuncaoDTO>> GetFuncao(int id)
        {
            var funcao = await _context.Funcaos
                .Include(f => f.Users) // Carregar os usuários associados à função
                .FirstOrDefaultAsync(f => f.IdFuncao == id); //buscar a primeira função que tenha um ID correspondente ao ID fornecido na solicitação

            if (funcao == null)
            {
                return NotFound();
            }

            // Extrair apenas os IDs dos usuários associados à função
            var idsUsers = funcao.Users.Select(u => u.IdUser).ToList();

            var funcaoDTO = new FuncaoDTO()
            {
                IdFuncao = funcao.IdFuncao,
                NomeFuncao = funcao.NomeFuncao,
                IdsUsers = idsUsers // Incluir os IDs dos usuários associados na DTO
            };

            return funcaoDTO;
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<FuncaoDTO>> PutFuncao(int id, FuncaoDTO funcaoDTO)
        {
            if (id != funcaoDTO.IdFuncao)
            {
                return BadRequest();
            }

            // Busca a função no banco de dados com base no id fornecido
            var funcao = await _context.Funcaos.FindAsync(id);

            // Verifica se a função não foi encontrada no banco de dados
            if (funcao == null)
            {
                // Se a função não foi encontrada, retorna uma resposta NotFound indicando que a função não existe
                return NotFound();
            }

            // Atualiza as propriedades da entidade Funcao com base nos dados do DTO
            funcao.IdFuncao = funcaoDTO.IdFuncao;
            funcao.NomeFuncao = funcaoDTO.NomeFuncao;

            // Marca o estado da entidade funcao como modificado
            _context.Entry(funcao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Converte a entidade Funcao para um DTO antes de retornar
            FuncaoDTO funcaoAtualizadaDTO = new FuncaoDTO()
            {
                IdFuncao = funcao.IdFuncao,
                NomeFuncao = funcao.NomeFuncao
            };

            return funcaoAtualizadaDTO;
        }


        // POST: api/Funcao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FuncaoDTO>> PostFuncao(FuncaoDTO funcaoDTO)
        {
            // Converte o DTO em um objeto Funcao usando o método DtoToFuncaoModel
            Funcao funcao = funcaoDTO.DtoToFuncaoModel();

            // Define a data de criação como a data e hora atuais
            funcao.DataCriacao = DateTime.Now;
            funcao.DataAtualizacao = DateTime.Now;

            // Adiciona a nova função ao contexto do banco de dados
            _context.Funcaos.Add(funcao);

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            // Retorna um resultado CreatedAtAction com o DTO da função recém-criada
            FuncaoDTO novaFuncaoDTO = new FuncaoDTO().FuncaoModelToDto(funcao);

            return CreatedAtAction("GetFuncao", new { id = novaFuncaoDTO.IdFuncao }, novaFuncaoDTO);
        }


        // DELETE: api/Funcao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncao(int id)
        {
            // Buscar a função no banco de dados com base no id fornecido
            var funcao = await _context.Funcaos.FindAsync(id);
            if (funcao == null)
            {
                return NotFound();
            }

            // Definir o nome da função diretamente no código (opcional)
            string nomeFuncao = funcao.NomeFuncao;
            // Define a data de criação como a data e hora atuais
            funcao.DataCriacao = DateTime.Now;
            funcao.DataAtualizacao = DateTime.Now;

            // Remover a função do contexto
            _context.Funcaos.Remove(funcao);
            await _context.SaveChangesAsync();

            // Converter a entidade Funcao removida para um DTO antes de retornar
            FuncaoDTO funcaoRemovidaDTO = new FuncaoDTO()
            {
                IdFuncao = funcao.IdFuncao,
                NomeFuncao = nomeFuncao
            };

            return NoContent();
        }

        private bool FuncaoExists(int id)
        {
            return _context.Funcaos.Any(e => e.IdFuncao == id);
        }
    }
}
