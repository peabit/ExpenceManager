using Entities;
using Repositories.Interfaces;

namespace Services;

public class ServiceBase<TEntity> where TEntity : Entity, new()
{
    protected readonly IRepository<TEntity> _repository;

    public ServiceBase(IRepository<TEntity> repository)
        => _repository = repository;
}