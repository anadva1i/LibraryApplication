using LibraryApplication.Domain;
using MediatR;

namespace LibraryApplication.Services.Commands
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
