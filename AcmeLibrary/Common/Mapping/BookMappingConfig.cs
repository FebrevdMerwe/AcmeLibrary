using AcmeLibrary.Application.Books.Queries;
using AcmeLibrary.Application.Clients.Commands;
using AcmeLibrary.Contracts.Books;
using Mapster;

namespace AcmeLibrary.Api.Common.Mapping
{
    public class BookMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddBookRequest, AddClientCommand>();
        }
    }
}
