using LibraryApplication.Domain;
using LibraryApplication.Services.DTOs;
using MediatR;

namespace LibraryApplication.Services.Queries
{
    public class GetBooksByAuthorQuery : IRequest<PagedResult<Book>>
    {
        public int AuthorId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalBooks { get; set; }
    }
}
