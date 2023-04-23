using LibraryApplication.Core.Interfaces;
using LibraryApplication.Domain;
using LibraryApplication.Services.Commands;
using MediatR;

namespace LibraryApplication.Services.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            // Perform business logic for updating a book
            // Use the repository to interact with the database
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null)
            {
                // Handle case where book is not found
                // Return appropriate response or throw an exception
                // depending on your business logic
                //throw new NotFoundException("Book not found");
            }

            // Update the book properties
            book.Title = request.Title;
            book.Description = request.Description;

            //await _bookRepository.SaveChangesAsync();

            return book;
        }
    }
}
