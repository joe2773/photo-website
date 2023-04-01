// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using MyPhotoApp.Domain.Models;
// using MyPhotoApp.Infrastructure.Data;

// namespace MyPhotoApp.Infrastructure.Repositories
// {
//     public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
//     {
//         protected readonly AppDbContext Context;
//         protected readonly DbSet<TEntity> DbSet;

//         public EFRepository(AppDbContext context)
//         {
//             Context = context;
//             DbSet = context.Set<TEntity>();
//         }

//         public async Task<TEntity> GetByIdAsync(int id)
//         {
//             return await DbSet.FindAsync(id);
//         }

//         public async Task<IEnumerable<TEntity>> GetAllAsync()
//         {
//             return await DbSet.ToListAsync();
//         }

//         public async Task AddAsync(TEntity entity)
//         {
//             await DbSet.AddAsync(entity);
//         }

//         public Task UpdateAsync(TEntity entity)
//         {
//             DbSet.Update(entity);
//         }

//         public Task DeleteAsync(TEntity entity)
//         {
//             DbSet.Remove(entity);
//         }
//     }
// }
