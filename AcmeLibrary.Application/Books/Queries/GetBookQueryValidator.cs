using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Books.Queries
{
    public class GetBookQueryValidator : AbstractValidator<GetBookQuery>
    {
        public GetBookQueryValidator()
        {
            RuleFor(x => x.Isbn).NotEmpty();
            RuleFor(x => x.Isbn.Trim().Replace("-", "")).Length(13);
        }
    }
}
