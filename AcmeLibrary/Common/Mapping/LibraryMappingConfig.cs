using AcmeLibrary.Application.Libraries.Commands;
using AcmeLibrary.Contracts.Libraries;
using AcmeLibrary.Domain.LibraryAggregate;
using Mapster;

namespace AcmeLibrary.Api.Common.Mapping
{
    public class LibraryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateLibraryRequest, CreateLibraryCommand>()
                .Map(dest => dest.Name, src => src.Name);

            config.NewConfig<Library, LibraryResponse>()
                .Map(dest=>dest.Id, src => src.Id.Value)
                .Map(dest=>dest.Name, src=>src.Name);
        }
    }
}
