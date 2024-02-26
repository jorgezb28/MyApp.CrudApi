using Microsoft.AspNetCore.Mvc;
using MyApp.CrudApi.Domain.Models;
using MyApp.CrudApi.Services.IServices;

namespace MyApp.CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberServices _memberServices;

        public MembersController(IMemberServices memberServices)
        {
            _memberServices = memberServices;
        }

        [HttpPost("api/members/add-members")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMember(MemberModel member)
        {
            if (member is not null)
            {
                _memberServices.Insert(member);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("api/members/get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var members = _memberServices.GetAll();

            if (members is not null)
            {
                return Ok(members);
            }

            return NotFound();
        }


        [HttpGet("api/members/get-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var member = _memberServices.GetById(id);

            if (member is not null)
            {
                return Ok(member);
            }

            return NotFound();
        }

        [HttpPut("api/members/edit-member")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditMember(MemberModel member)
        {
            if (member is not null)
            {
                _memberServices.Update(member);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("api/members/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(MemberModel member)
        {
            if (member is not null)
            {
                _memberServices.Delete(member);
                return Ok();
            }

            return NotFound();
        }
    }
}
