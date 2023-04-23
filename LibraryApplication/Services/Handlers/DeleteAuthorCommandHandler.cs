using LibraryApplication.Core.Interfaces;
using LibraryApplication.Services.Commands;
using MediatR;

namespace LibraryApplication.Services.Handlers
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
    {
        private readonly IAuthorRepository _authorRepository;
        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(request.AuthorId);
            if (author == null)
            {
                throw new Exception("Author not found");
            }

            await _authorRepository.DeleteAsync(author);
            return Unit.Value;
        }
    }
}
