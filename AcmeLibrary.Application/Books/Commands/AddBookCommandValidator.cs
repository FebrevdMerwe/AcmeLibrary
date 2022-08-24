using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Books.Commands
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(x => x.Isbn).NotEmpty();
            RuleFor(x => x.Isbn.Trim().Replace("-","")).Length(13);
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
        }
    }
}
