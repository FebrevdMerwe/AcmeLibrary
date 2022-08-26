using AcmeLibrary.Application.Clients.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Clients.Commands
{
    public class AddClientCommandValidator : AbstractValidator<AddClientCommand>
    {
        public AddClientCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
