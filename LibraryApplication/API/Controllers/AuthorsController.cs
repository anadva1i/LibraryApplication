using LibraryApplication.Data.Interfaces;
using LibraryApplication.Services.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateAuthor(AddAuthorCommand command)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var result = await _mediator.Send(command);
                _unitOfWork.Commit();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var command = new DeleteAuthorCommand { AuthorId = id };
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
