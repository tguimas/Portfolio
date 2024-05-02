using GestaoParquesAPI.Models;
using System.Collections.Generic;

namespace GestaoParquesAPI.DTOs
{
    public class FuncaoDTO
    {
        public int IdFuncao { get; set; }

        public string NomeFuncao { get; set; } = null!;

        // Troque Users por IdsUsers para armazenar apenas os IDs dos usuários
        public List<int> IdsUsers { get; set; } = new List<int>();

        // DtoToModel
        public Funcao DtoToFuncaoModel()
        {
            Funcao funcao = new Funcao
            {
                IdFuncao = this.IdFuncao,
                NomeFuncao = this.NomeFuncao,
                // Não mapeie Users aqui, pois o DTO deve conter apenas IDs
            };

            return funcao;
        }

        // ModelToDto
        public FuncaoDTO FuncaoModelToDto(Funcao funcao)
        {
            FuncaoDTO dto = new FuncaoDTO
            {
                IdFuncao = funcao.IdFuncao,
                NomeFuncao = funcao.NomeFuncao,
                // Mapeie apenas os IDs dos usuários    
                IdsUsers = funcao.Users != null ? funcao.Users.Select(u => u.IdUser).ToList() : new List<int>() // ternário
            };

            return dto;
        }
    }
}
