using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.CrudApi.Domain.DTOs;
using MyApp.CrudApi.Services.IServices;

namespace MyApp.CrudApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberServices _memberServices;

        public MembersController(IMemberServices memberServices)
        {
            _memberServices = memberServices;
        }

        [HttpPost("add-members")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMember(MemberDto member)
        {
            if (member is not null)
            {
                _memberServices.Insert(member);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("get-all")]
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


        [HttpGet("get-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {

            if (id <= 0) return BadRequest();

            var member = _memberServices.GetById(id);

            if (member is not null)
            {
                return Ok(member);
            }

            return NotFound();
        }

        [HttpPut("edit-member")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditMember(MemberDto member)
        {
            if (member is not null)
            {
                _memberServices.Update(member);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(MemberDto member)
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
