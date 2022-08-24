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
            RuleFor(x => x.ISBN).NotEmpty();
            RuleFor(x => x.ISBN.Trim().Replace("-", "")).Length(13);
        }
    }
}
