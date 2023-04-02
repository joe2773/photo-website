using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPhotoApp.Application.Services;
using MyPhotoApp.Application.Dto;
using Swashbuckle.AspNetCore.Annotations;


namespace MyPhotoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [SwaggerOperation("GetUser")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<UserDto>> GetAllUsers(){
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("GetUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> GetUser(int id){
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch(ArgumentException ex){
                return NotFound(ex.Message);
            }
            catch(Exception ex){
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation("CreateUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateUser([FromBody] UserDto user){
            try{
            await _userService.CreateUserAsync(user);
            return Ok(user);
            }
            catch(ArgumentException ex){
                return NotFound(ex.Message);
            }
            catch(InvalidDataException ex){
                return BadRequest(ex.Message);
            }
            catch(Exception ex){
                return StatusCode(500,ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteUser")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteUser(int id){
            try{
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch(ArgumentException ex){
                return NotFound(ex.Message);
            }
            catch(Exception ex){
                return StatusCode(500,ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        [SwaggerOperation("UpdateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDto user){
            try
            {
                await _userService.UpdateUserAsync(id, user);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
