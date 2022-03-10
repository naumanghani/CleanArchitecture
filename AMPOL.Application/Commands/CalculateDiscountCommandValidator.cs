using AMPOL.Application.Common.Interfaces;
using AMPOL.Application.Common.Mapping;
using AMPOL.Application.DTOs;
using AMPOL.Domain.Entities;
using AMPOL.Domain.Enums;
using AutoMapper;
using FluentValidation;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AMPOL.Application.Commands
{
    public class CalculateDiscountCommandValidator : AbstractValidator<CalculateDiscountCommand>
    {
        public CalculateDiscountCommandValidator()
        {
            RuleFor(v => v.CustomerId)
                .NotEmpty();

            RuleFor(v => v.Basket.Count)
                .GreaterThan(0);

            RuleForEach(v => v.Basket)
                .SetValidator(new CalculateDiscountCommandChildValidator());
        }

    }
}
