using LibraryApplication.Domain;
using LibraryApplication.Services.DTOs;
using MediatR;

namespace LibraryApplication.Services.Queries
{
    public class GetBooksQuery : IRequest<PagedResult<Book>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalBooks { get; set; }
    }
}
