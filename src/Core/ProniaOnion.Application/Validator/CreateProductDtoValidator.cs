using FluentValidation;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Validator
{
    public class CreateProductDtoValidator:AbstractValidator<CreateProductDto>
    {
        public const int NAME_MAX_LENGTH = 100;
        public CreateProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                    .WithMessage("Name is required")
                .MaximumLength(NAME_MAX_LENGTH);
            RuleFor(p=>p.SKU).NotEmpty().MinimumLength(4).MaximumLength(10);

            RuleFor(p => p.Description).NotEmpty();

            RuleFor(p=>p.Price).GreaterThanOrEqualTo(4).LessThanOrEqualTo(9999.99m);

            RuleFor(p=>p.CategoryID)
                .NotEmpty()
                .Must(id=>id>0);

            RuleForEach(p=>p.ColorIds)
                .Must(id=>id>0);
            RuleFor(p=>p.ColorIds).Must(ci=>ci.Count>0).NotEmpty();
        }
    }
}
