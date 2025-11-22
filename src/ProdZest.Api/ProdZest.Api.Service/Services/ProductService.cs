using AutoMapper;
using FluentValidation;
using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Interfaces.Repository;
using ProdZest.Api.Domain.Interfaces.Service;
using System.Linq.Expressions;

namespace ProdZest.Api.Service.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<Product> _validator;
    public ProductService(IProductRepository productRepository, IMapper mapper, IValidator<Product> validator)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<Product> AddAsync(Product entity)
    {
        var result = await _productRepository.AddAsync(entity);
        return result;
    }

    public async Task AddRangeAsync(IList<Product> entity)
    {
        await _productRepository.AddRangeAsync(entity);
    }

    public async Task<Product> DeleteAsync(long Id)
    {
        var result = await _productRepository.DeleteAsync(Id);
        return result;
    }

    public Task<Product> DeleteAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRangeAsync(IList<Product> entities)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>> predicate)
    {
        var result = _productRepository.GetAllAsync(predicate);
        return result;
    }

    public Task<Product> GetAsync(Expression<Func<Product, bool>> predicate)
    {
        var result = _productRepository.GetAsync(predicate);
        return result;
    }

    public async Task<Product> GetByIdAsync(long Id)
    {
        var result = await _productRepository.GetByIdAsync(Id);
        return result;
    }

    public async Task<Product> UpdateAsync(Product entity)
    {
        var result = await _productRepository.UpdateAsync(entity);
        return result;
    }

    public async Task UpdateRangeAsync(IEnumerable<Product> entity)
    {
        await _productRepository.UpdateRangeAsync(entity);
    }
}
