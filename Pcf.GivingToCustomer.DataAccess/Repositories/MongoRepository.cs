using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Pcf.GivingToCustomer.Core.Domain;

namespace Pcf.GivingToCustomer.DataAccess.Repositories
{
    public class MongoRepository<T>
        : IRepository<T>
        where T: BaseEntity
    {
        private readonly IMongoCollection<T> _collection;
        private readonly IClientSessionHandle _session;

        public MongoRepository(IMongoCollection<T> collection, IClientSessionHandle session)
        {
            _collection = collection;
            _session = session;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Aggregate(_session).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _collection
                .Find(_session, x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids)
        {
            return await _collection
                .Find(_session, x => ids.Contains(x.Id))
                .ToListAsync();
        }

        public async Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate)
        {
            return await _collection
                .Find(_session, predicate)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(_session, predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(_session, entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync<T>(_session,
                x => x.Id == entity.Id,
                entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _collection.DeleteOneAsync(_session, x => x.Id == entity.Id);
        }
    }
    
    
}
