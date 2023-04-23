using LibraryApplication.Core.Interfaces;
using LibraryApplication.Domain;
using LibraryApplication.Services.DTOs;
using LibraryApplication.Services.Queries;
using MediatR;

namespace LibraryApplication.Services.Handlers
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, PagedResult<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<PagedResult<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            // Get total count of books by authorId
            int totalBooks = _bookRepository.GetTotalBooks();

            // Calculate number of items to skip and take
            int itemsToSkip = (request.PageNumber - 1) * request.PageSize;
            int itemsToTake = request.PageSize;
            // Call repository method with page size and page number for pagination
            var books = await _bookRepository.GetAllAsync(itemsToSkip, itemsToTake);

            var pagedResult = new PagedResult<Book>(books, totalBooks, request.PageNumber, request.PageSize);

            return pagedResult;
        }
    }
}
