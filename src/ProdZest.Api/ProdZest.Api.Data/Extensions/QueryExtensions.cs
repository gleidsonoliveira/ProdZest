using ProdZest.Api.Domain.Dtos.Paginacao;
using ProdZest.Api.Domain.Dtos.Paginacao.Filter;

namespace ProdZest.Api.Data.Extensions;
public static class QueryExtensions
{
    public static PagedResponse<IEnumerable<T>> CriarRespostaPaginada<T>(this IEnumerable<T> dadosPaginados, IFiltroPaginacao filtro, long totalRegistros)
    {
        _ = dadosPaginados ?? throw new ArgumentNullException(nameof(dadosPaginados));
        _ = filtro ?? throw new ArgumentNullException(nameof(filtro));

        var resposta = new PagedResponse<IEnumerable<T>>(dadosPaginados, filtro.PaginaNumero, filtro.PaginaTamanho);
        var totalPaginas = totalRegistros / (double)filtro.PaginaTamanho;
        int totalPaginasInt = Convert.ToInt32(Math.Ceiling(totalPaginas));
        resposta.TotalPages = totalPaginasInt;
        resposta.TotalRecords = totalRegistros;
        return resposta;
    }

    public static string AdicionarPaginacaoScript(this string script)
    {
        return $"{script.TrimEnd(';', ' ')} LIMIT @linhasPular, @linhasObter;";
    }
}
