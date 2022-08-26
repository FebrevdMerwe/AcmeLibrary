using FluentValidation;

namespace AcmeLibrary.Application.Clients.Queries
{
    public class GetClientQueryValidator : AbstractValidator<GetClientQuery>
    {
        public GetClientQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}