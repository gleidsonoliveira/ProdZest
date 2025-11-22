namespace ProdZest.Api.Domain.Dtos.Paginacao;
public class Resposta<T>
{
    public Resposta(T dados)
    {
        Sucesso = true;
        Mensagem = string.Empty;
        Erros = null;
        Dados = dados;
    }
    public T Dados { get; set; }
    public bool Sucesso { get; set; }
    public IEnumerable<string> Erros { get; set; }
    public string Mensagem { get; set; }
}
