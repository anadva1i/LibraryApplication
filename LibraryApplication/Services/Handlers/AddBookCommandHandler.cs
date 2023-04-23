using LibraryApplication.Core.Interfaces;
using LibraryApplication.Domain;
using LibraryApplication.Services.Commands;
using MediatR;

namespace LibraryApplication.Services.Handlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book { Title = request.Title, Description = request.Description, AuthorId = request.AuthorId };
            await _bookRepository.AddAsync(book);
            return book;
        }
    }
}
