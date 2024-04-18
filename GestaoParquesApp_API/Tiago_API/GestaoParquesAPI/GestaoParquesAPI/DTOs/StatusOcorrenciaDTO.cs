using GestaoParquesAPI.Models;

namespace GestaoParquesAPI.DTOs
{
    public class StatusOcorrenciaDTO
    {
        public int IdStatusOcorrencia { get; set; }

        public string DescricaoStatus { get; set; } = null!;

        public bool Inativo { get; set; }



        public StatusOcorrencium DtoToStatusOcorrenciaModel()
        {
            StatusOcorrencium statusOcorrencia = new StatusOcorrencium
            {
                IdStatusOcorrencia = this.IdStatusOcorrencia,
                DescricaoStatus = this.DescricaoStatus,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            return statusOcorrencia;
        }

        public StatusOcorrenciaDTO StatusOcorrenciaModelToDto(StatusOcorrencium statusOcorrencia)
        {
            StatusOcorrenciaDTO dtoStatusOcorrecia = new StatusOcorrenciaDTO
            {
                IdStatusOcorrencia = statusOcorrencia.IdStatusOcorrencia,
                DescricaoStatus = statusOcorrencia.DescricaoStatus
            };
            return dtoStatusOcorrecia;
        }



    }
}
