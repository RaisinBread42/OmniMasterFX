using OmniMasterFX.Application.Products.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OmniMasterFX.Application.Products.Validators
{
    public class GetProductDetailsQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("Product Id must not be 0.");
        }
    }
}
