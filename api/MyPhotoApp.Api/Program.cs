using MyPhotoApp.Application.Services;
using MyPhotoApp.Infrastructure.Data;
using MyPhotoApp.Infrastructure.Repositories;
using MyPhotoApp.Application.MappingProfiles;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Register services and repositories
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=MyPhotoApp.db"));

builder.Services.AddControllers();


// Add services to the container.

builder.Services.AddControllers();

// Register automapper
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(MyPhotoApp.Application.Dto.LikeDto).Assembly);
builder.Services.AddAutoMapper(typeof(MyPhotoApp.Application.Dto.PhotoDto).Assembly);
builder.Services.AddAutoMapper(typeof(MyPhotoApp.Application.Dto.CommentDto).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
