using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPhotoApp.Application.Dto;
using MyPhotoApp.Application.Services;

namespace MyPhotoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        /// <summary>
        /// Get a like by ID
        /// </summary>
        /// <param name="id">The ID of the like to get</param>
        /// <returns>The requested like</returns>
        /// <response code="200">Returns the requested like</response>
        /// <response code="400">If the ID is not valid</response>
        /// <response code="404">If the like with the given ID does not exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LikeDto>> GetLikeByIdAsync(int id)
        {
            try
            {
                var like = await _likeService.GetLikeByIdAsync(id);

                return Ok(like);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Get all likes
        /// </summary>
        /// <returns>All likes</returns>
        /// <response code="200">Returns all likes</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LikeDto>>> GetAllLikesAsync()
        {
            try
            {
                var likes = await _likeService.GetAllLikesAsync();
                return Ok(likes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Create a new like
        /// </summary>
        /// <param name="like">The like to create</param>
        /// <returns>A NoContent response</returns>
        /// <response code="204">If the like was created successfully</response>
        /// <response code="400">If the like is invalid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateLikeAsync(LikeDto like)
        {
            try
            {
                await _likeService.CreateLikeAsync(like);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        

        /// <summary>
        /// Delete a like
        /// </summary>
        /// <param name="id">The ID of the like to delete</param>
        /// <returns>A NoContent response</returns>
        /// <response code="204">If the like was deleted successfully</response>
        /// <response code="400">If the ID is not valid</response>
        /// <response code="404">If the like with the given ID does not exist</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteLikeAsync(int id){
            try{
                await _likeService.DeleteLikeAsync(id);
                return NoContent();
            }
            catch(ArgumentException ex){
                return NotFound(ex.Message);
            }
            catch(Exception ex){
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
