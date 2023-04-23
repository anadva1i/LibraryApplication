using LibraryApplication.Core.Interfaces;
using LibraryApplication.Domain;
using LibraryApplication.Services.DTOs;
using LibraryApplication.Services.Queries;
using MediatR;

namespace LibraryApplication.Services.Handlers
{
    public class GetBooksByAuthorQueryHandler : IRequestHandler<GetBooksByAuthorQuery, PagedResult<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksByAuthorQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<PagedResult<Book>> Handle(GetBooksByAuthorQuery request, CancellationToken cancellationToken)
        {
            int totalBooks = _bookRepository.GetTotalBooksByAuthorId(request.AuthorId);
            int itemsToSkip = (request.PageNumber - 1) * request.PageSize;
            int itemsToTake = request.PageSize;

            var books = await _bookRepository.GetBooksByAuthorIdAsync(request.AuthorId, itemsToSkip, itemsToTake);

            var pagedResult = new PagedResult<Book>(books, totalBooks, request.PageNumber, request.PageSize);

            return pagedResult;
        }
    }
}
