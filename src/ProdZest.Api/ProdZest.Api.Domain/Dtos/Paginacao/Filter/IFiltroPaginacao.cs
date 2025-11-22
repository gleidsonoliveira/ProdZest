namespace ProdZest.Api.Domain.Dtos.Paginacao.Filter;
public interface IFiltroPaginacao
{
    int PaginaNumero { get; set; }
    int PaginaTamanho { get; set; }
}
