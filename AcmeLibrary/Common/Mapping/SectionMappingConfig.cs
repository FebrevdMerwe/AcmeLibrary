using AcmeLibrary.Application.Sections.Commands;
using AcmeLibrary.Contracts.Sections;
using AcmeLibrary.Domain.SectionAggregate;
using Mapster;

namespace AcmeLibrary.Api.Common.Mapping
{
    public class SectionMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateSectionRequest, CreateSectionCommand>();

            config.NewConfig<Section, SectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.LibraryId, src => src.LibraryId.Value);
        }
    }
}
