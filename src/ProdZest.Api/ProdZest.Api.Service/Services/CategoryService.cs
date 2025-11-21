using AutoMapper;
using FluentValidation;
using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Interfaces.Repository;
using ProdZest.Api.Domain.Interfaces.Service;
using System.Linq.Expressions;

namespace ProdZest.Api.Service.Services;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<Category> _validator;
    public CategoryService(ICategoryRepository CategoryRepository, IMapper mapper, IValidator<Category> validator)
    {
        _categoryRepository = CategoryRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Category> AddAsync(Category entity)
    {
        var result = await _categoryRepository.AddAsync(entity);
        return result;
    }

    public async Task AddRangeAsync(IList<Category> entity)
    {
        await _categoryRepository.AddRangeAsync(entity);
    }

    public async Task<Category> DeleteAsync(long Id)
    {
        var result = await _categoryRepository.DeleteAsync(Id);
        return result;
    }

    public Task<Category> DeleteAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRangeAsync(IList<Category> entities)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>> predicate)
    {
        var result = _categoryRepository.GetAllAsync(predicate);
        return result;
    }

    public Task<Category> GetAsync(Expression<Func<Category, bool>> predicate)
    {
        var result = _categoryRepository.GetAsync(predicate);
        return result;
    }

    public async Task<Category> GetByIdAsync(long Id)
    {
        var result = await _categoryRepository.GetByIdAsync(Id);
        return result;
    }

    public async Task<Category> UpdateAsync(Category entity)
    {
        var result = await _categoryRepository.UpdateAsync(entity);
        return result;
    }

    public async Task UpdateRangeAsync(IEnumerable<Category> entity)
    {
        await _categoryRepository.UpdateRangeAsync(entity);
    }
}