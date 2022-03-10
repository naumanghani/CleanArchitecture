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
    public class CalculateDiscountCommandChildValidator : AbstractValidator<CalculateDiscountCommandChild>
    {
        public CalculateDiscountCommandChildValidator()
        {
            RuleFor(v => v.ProductId)
                .NotEmpty();
        }

    }
}
