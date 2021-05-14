using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shodan.RomanDates.Api.Features.Shared.Repositories.Interfaces;

namespace Shodan.RomanDates.Api.Features.Shared.Repositories
{
    public class Repository : IRepository
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configuration;

        public Repository(DbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
            this._configuration = this._mapper.ConfigurationProvider;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllEntities<TEntity>()
            where TEntity : class
            => await this._context.Set<TEntity>()
            .ToListAsync();

        public virtual async Task<IEnumerable<TModel>> GetAllEntities<TEntity, TModel>()
            where TEntity : class
            where TModel : class
            => await this._context.Set<TEntity>()
            .ProjectTo<TModel>(this._configuration)
            .ToListAsync();

        public virtual async Task<IEnumerable<TEntity>> GetEntities<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : class
            => await this._context.Set<TEntity>()
            .Where(query)
            .ToListAsync();

        public virtual async Task<IEnumerable<TModel>> GetEntities<TEntity, TModel>(Expression<Func<TEntity, bool>> query)
            where TEntity : class
            where TModel : class
            => await this._context.Set<TEntity>()
            .Where(query)
            .ProjectTo<TModel>(this._configuration)
            .ToListAsync();

        public virtual async Task<TEntity> GetEntity<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : class
            => await this._context.Set<TEntity>()
            .FirstOrDefaultAsync(query);

        public virtual async Task<TModel> GetEntity<TEntity, TModel>(Expression<Func<TEntity, bool>> query)
            where TEntity : class
            where TModel : class
            => await this._context.Set<TEntity>()
            .Where(query)
            .ProjectTo<TModel>(this._configuration)
            .FirstOrDefaultAsync();

        public virtual async Task<bool> UpdateEntity<TEntity>(TEntity entity)
            where TEntity : class
        {
            _ = this._context.Set<TEntity>().Update(entity);
            var result = await this._context.SaveChangesAsync();

            return result != 0;
        }

        public virtual async Task<bool> UpdateEntity<TEntity, TModel>(TModel model)
            where TEntity : class
            where TModel : class
        {
            var mappedEntity = this._mapper.Map<TEntity>(model);

            return await this.UpdateEntity(mappedEntity);
        }

        public virtual async Task<bool> UpdateEntities<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class
        {
            this._context.Set<TEntity>().UpdateRange(entities);
            var result = await this._context.SaveChangesAsync();

            return result != 0;
        }

        public virtual async Task<bool> UpdateEntities<TEntity, TModel>(IEnumerable<TModel> models)
            where TEntity : class
            where TModel : class
        {
            var mappedEntities = this._mapper.Map<IEnumerable<TEntity>>(models);

            return await this.UpdateEntities(mappedEntities);
        }

        public virtual async Task<bool> UpdateEntities<TEntity>(Expression<Func<TEntity, bool>> query, Func<TEntity, TEntity> update)
            where TEntity : class
        {
            var entity = this._context.Set<TEntity>().Where(query).AsEnumerable().Select(update);

            if (entity is null || !entity.Any())
            {
                return false;
            }

            var result = await this._context.SaveChangesAsync();

            return result != 0;
        }

        public virtual async Task<(bool success, TEntity entity)> InsertEntity<TEntity>(TEntity entity)
            where TEntity : class
        {
            var newEntity = await this._context.Set<TEntity>().AddAsync(entity);
            var result = await this._context.SaveChangesAsync();

            return (result != 0, newEntity.Entity);
        }

        public virtual async Task<(bool success, TEntity entity)> InsertEntity<TEntity, TModel>(TModel model)
            where TEntity : class
            where TModel : class
        {
            var mappedEntity = this._mapper.Map<TEntity>(model);

            return await this.InsertEntity(mappedEntity);
        }

        public virtual async Task<bool> InsertEntities<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class
        {
            await this._context.Set<TEntity>().AddRangeAsync(entities);
            var result = await this._context.SaveChangesAsync();

            return result != 0;
        }

        public virtual async Task<bool> InsertEntities<TEntity, TModel>(IEnumerable<TModel> models)
            where TEntity : class
            where TModel : class
        {
            var mappedEntities = this._mapper.Map<IEnumerable<TEntity>>(models);

            return await this.InsertEntities(mappedEntities);
        }

        public virtual async Task<bool> UpsertEntities<TEntity>(Expression<Func<TEntity, bool>> query, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            var items = this._context.Set<TEntity>().Where(query);
            if (!(items is null) && items.Any())
            {
                this._context.RemoveRange(items);
            }

            await this._context.Set<TEntity>().AddRangeAsync(entities);
            var result = await this._context.SaveChangesAsync();

            return result != 0;
        }

        public virtual async Task<bool> UpsertEntities<TEntity, TModel>(Expression<Func<TEntity, bool>> query, IEnumerable<TModel> models)
            where TEntity : class
            where TModel : class
        {
            var mappedEntities = this._mapper.Map<IEnumerable<TEntity>>(models);

            return await this.UpsertEntities<TEntity>(query, mappedEntities);
        }

        public virtual async Task<bool> UpsertEntity<TEntity>(Expression<Func<TEntity, bool>> query, TEntity entity)
            where TEntity : class
        {
            var item = await this._context.Set<TEntity>().FirstOrDefaultAsync(query);
            if (!(item is null))
            {
                _ = this._context.Remove(item);
            }

            _ = await this._context.Set<TEntity>().AddAsync(entity);

            var result = await this._context.SaveChangesAsync();

            return result != 0;
        }

        public virtual async Task<bool> UpsertEntity<TEntity, TModel>(Expression<Func<TEntity, bool>> query, TModel model)
            where TEntity : class
            where TModel : class
        {
            var mappedEntity = this._mapper.Map<TEntity>(model);

            return await this.UpsertEntity<TEntity>(query, mappedEntity);
        }

        public virtual async Task<int> Count<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : class
            => await this._context.Set<TEntity>()
            .CountAsync(query);
    }
}
