using FluentValidation;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Application.Dto;

public class PhotoValidator : AbstractValidator<UserDto>
{
    public PhotoValidator()
    {
        
    }
}
