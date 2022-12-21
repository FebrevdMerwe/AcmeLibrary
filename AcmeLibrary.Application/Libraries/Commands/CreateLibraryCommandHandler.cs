using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.LibraryAggregate;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Libraries.Commands
{
    public class CreateLibraryCommandHandler : IRequestHandler<CreateLibraryCommand, ErrorOr<Library>>
    {
        private readonly ILibraryRepository _libraryRepository;

        public CreateLibraryCommandHandler(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task<ErrorOr<Library>> Handle(CreateLibraryCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var library = Library.Create(request.Name);

            _libraryRepository.Add(library);

            return library;
        }
    }
}
