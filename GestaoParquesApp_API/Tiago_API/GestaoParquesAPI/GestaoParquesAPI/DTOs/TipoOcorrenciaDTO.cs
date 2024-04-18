using GestaoParquesAPI.Models;

namespace GestaoParquesAPI.DTOs
{
    public class TipoOcorrenciaDTO
    {
        public int IdTipoOcorrencia { get; set; }

        public string NomeTipoOcorrencia { get; set; } = null!;

        public bool Inativo { get; set; }


        public TipoOcorrencium DtoToTipocorrenciaModel()
        {
            TipoOcorrencium ocorrecia = new TipoOcorrencium
            {
                IdTipoOcorrencia = this.IdTipoOcorrencia,
                NomeTipoOcorrencia = this.NomeTipoOcorrencia,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            return ocorrecia;
        }

        public TipoOcorrenciaDTO TipoOcorrenciaModelToDto(TipoOcorrencium ocorrencia)
        {
            TipoOcorrenciaDTO dtoTipoOcorrecia = new TipoOcorrenciaDTO
            {
                IdTipoOcorrencia = ocorrencia.IdTipoOcorrencia,
                NomeTipoOcorrencia = ocorrencia.NomeTipoOcorrencia
            };
            return dtoTipoOcorrecia;
        }

        }
    }
