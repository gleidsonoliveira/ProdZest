using ProdZest.Api.Domain.Entities.Base;

namespace ProdZest.Api.Domain.Entities;
public class Category : EntityBase
{
    public string Description { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}
