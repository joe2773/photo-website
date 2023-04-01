using System;
using System.Threading.Tasks;
using MyPhotoApp.Domain.Models;

namespace MyPhotoApp.Infrastructure.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Photo> Photos { get; }
        IRepository<Like> Likes { get; }
        IRepository<Comment> Comments { get; }

        Task<int> CommitAsync();
    }
}
