using LibraryApplication.Core.Interfaces;
using LibraryApplication.Domain;
using LibraryApplication.Services.Commands;
using MediatR;

namespace LibraryApplication.Services.Handlers
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public AddAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author { FirstName = request.FirstName, LastName = request.LastName };
            await _authorRepository.AddAsync(author);
            return author;
        }
    }
}
