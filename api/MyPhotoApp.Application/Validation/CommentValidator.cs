using FluentValidation;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Application.Dto;

public class CommentValidator : AbstractValidator<UserDto>
{
    public CommentValidator()
    {
        
    }
}
