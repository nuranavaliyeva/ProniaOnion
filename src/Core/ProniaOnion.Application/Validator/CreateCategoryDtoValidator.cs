using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Validator
{
    public class CreateCategoryDtoValidator:AbstractValidator<CreateCategoryDto>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryDtoValidator(ICategoryRepository repository)
        {
            _repository = repository;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Data required")
                .MaximumLength(100)
                .Matches(@"^[A-Za-z\s0-9]*$");
                //.MustAsync(CheckNameExistence);
               
        }
        public async Task<bool> CheckNameExistence(string name, CancellationToken token )
        {
            return !await _repository.AnyAsync(c => c.Name == name);
        }
    }
}
