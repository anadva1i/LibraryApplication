using MediatR;

namespace LibraryApplication.Services.Commands
{
    public class DeleteAuthorCommand : IRequest<Unit>
    {
        public int AuthorId { get; set; }
    }
}
