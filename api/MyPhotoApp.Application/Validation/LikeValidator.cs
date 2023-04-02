using FluentValidation;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Application.Dto;

public class LikeValidator : AbstractValidator<UserDto>
{
    public LikeValidator()
    {
        
    }
}
