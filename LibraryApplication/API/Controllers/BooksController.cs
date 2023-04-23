using LibraryApplication.Data.Interfaces;
using LibraryApplication.Domain;
using LibraryApplication.Services.Commands;
using LibraryApplication.Services.DTOs;
using LibraryApplication.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{currentPage}/{pageSize}")]
        public async Task<ActionResult<PagedResult<Book>>> GetBooks(int currentPage, int pageSize)
        {
            var query = new GetBooksQuery
            {
                PageNumber = currentPage,
                PageSize = pageSize
            };

            var pagedResult = await _mediator.Send(query);

            return Ok(pagedResult);
        }

        [HttpGet("{authorId}/{currentPage}/{pageSize}")]
        public async Task<ActionResult<PagedResult<Book>>> GetBooks(int authorId, int currentPage, int pageSize)
        {
            var query = new GetBooksByAuthorQuery
            {
                AuthorId = authorId,
                PageNumber = currentPage,
                PageSize = pageSize
            };

            var pagedResult = await _mediator.Send(query);

            return Ok(pagedResult);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateBook(AddBookCommand command)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var result = await _mediator.Send(command);
                _unitOfWork.Commit();
                return Ok(result);
            }
            catch(Exception)
            {
                _unitOfWork.Rollback();
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create book");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(UpdateBookCommand command)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var result = await _mediator.Send(command);
                await _unitOfWork.BookRepository.UpdateAsync(result);
                _unitOfWork.Commit();
                return Ok(result);
            }
            catch(Exception)
            {
                _unitOfWork.Rollback();
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update book");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var command = new DeleteBookCommand { BookId = id };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete book");
            }
        }
    }
}
