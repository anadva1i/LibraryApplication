using LibraryApplication.Domain;
using MediatR;

namespace LibraryApplication.Services.Commands
{
    public class AddBookCommand : IRequest<Book>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
    }
}
