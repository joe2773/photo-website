// using System.Threading.Tasks;
// using MyPhotoApp.Domain.Models;
// using MyPhotoApp.Infrastructure.Data;

// namespace MyPhotoApp.Infrastructure.Repositories
// {
//     public class EFUnitOfWork : IUnitOfWork
//     {
//         private readonly AppDbContext _context;

//         public EFUnitOfWork(AppDbContext context)
//         {
//             _context = context;
//             Users = new EFRepository<User>(context);
//             Photos = new EFRepository<Photo>(context);
//             Likes = new EFRepository<Like>(context);
//             Comments = new EFRepository<Comment>(context);
//         }

//         public IRepository<User> Users { get; }
//         public IRepository<Photo> Photos { get; }
//         public IRepository<Like> Likes { get; }
//         public IRepository<Comment> Comments { get; }

//         public async Task<int> CommitAsync()
//         {
//             return await _context.SaveChangesAsync();
//         }

//         public void Dispose()
//         {
//             _context.Dispose();
//         }
//     }
// }
