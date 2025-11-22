using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdZest.Api.Domain.Dtos.Paginacao.Filter;
public class FiltroPaginacao : IFiltroPaginacao
{
    public int PaginaNumero { get; set; }
    public int PaginaTamanho { get; set; }
    public FiltroPaginacao()
    {
        PaginaNumero = 1;
        PaginaTamanho = 40;
    }

    public FiltroPaginacao(int paginaNumero, int paginaTamanho)
    {
        PaginaNumero = paginaNumero < 1 ? 1 : paginaNumero;
        PaginaTamanho = paginaTamanho > 40 ? 40 : paginaTamanho;
    }
}
