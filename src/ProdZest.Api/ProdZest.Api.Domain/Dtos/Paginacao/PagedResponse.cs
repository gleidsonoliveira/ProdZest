namespace ProdZest.Api.Domain.Dtos.Paginacao;
/// <summary>
/// Classe que cria a paginação.
/// </summary>
/// <typeparam name="T"></typeparam>
public class PagedResponse<T> : Resposta<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public long TotalRecords { get; set; }

    public bool Next
    {
        get
        {
            return PageNumber >= 1 && PageNumber < TotalPages;
        }
    }

    public bool Previous
    {
        get
        {
            return PageNumber - 1 >= 1 && PageNumber <= TotalPages;
        }
    }

    public PagedResponse(T dados, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Dados = dados;
        Mensagem = null;
        Sucesso = true;
        Erros = null;
    }
}
