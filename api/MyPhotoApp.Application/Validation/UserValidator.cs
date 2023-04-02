using FluentValidation;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Application.Dto;

public class UserValidator : AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(user => user.Email).NotEmpty().EmailAddress();
    }
}
