using LibraryApplication.Domain;
using MediatR;

namespace LibraryApplication.Services.Commands
{
    public class AddAuthorCommand : IRequest<Author>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
