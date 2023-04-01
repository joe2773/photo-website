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
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        /// <summary>
        /// Get a photo by ID
        /// </summary>
        /// <param name="id">The ID of the photo to get</param>
        /// <returns>The requested photo</returns>
        /// <response code="200">Returns the requested photo</response>
        /// <response code="400">If the ID is not valid</response>
        /// <response code="404">If the photo with the given ID does not exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PhotoDto>> GetPhotoByIdAsync(int id)
        {
            try
            {
                var photo = await _photoService.GetPhotoByIdAsync(id);

                if (photo == null)
                {
                    return NotFound();
                }

                return Ok(photo);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Get all photos
        /// </summary>
        /// <returns>All photos</returns>
        /// <response code="200">Returns all photos</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PhotoDto>>> GetAllPhotosAsync()
        {
            try
            {
                var photos = await _photoService.GetAllPhotosAsync();
                return Ok(photos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Create a new photo
        /// </summary>
        /// <param name="photo">The photo to create</param>
        /// <returns>A NoContent response</returns>
        /// <response code="204">If the photo was created successfully</response>
        /// <response code="400">If the photo is invalid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePhotoAsync(PhotoDto photo)
        {
            try
            {
                await _photoService.CreatePhotoAsync(photo);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

                /// <summary>
        /// Update an existing photo
        /// </summary>
        /// <param name="id">The ID of the photo to update</param>
        /// <param name="photo">The updated photo</param>
        /// <returns>A NoContent response</returns>
        /// <response code="204">If the photo was updated successfully</response>
        /// <response code="400">If the photo is invalid or the ID is not valid</response>
        /// <response code="404">If the photo with the given ID does not exist</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePhotoAsync(int id, PhotoDto photo)
        {
            try
            {
                photo.Id = id;
                await _photoService.UpdatePhotoAsync(photo);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Delete a photo
        /// </summary>
        /// <param name="id">The ID of the photo to delete</param>
        /// <returns>A NoContent response</returns>
        /// <response code="204">If the photo was deleted successfully</response>
        /// <response code="400">If the ID is not valid</response>
        /// <response code="404">If the photo with the given ID does not exist</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePhotoAsync(int id)
        {
            try
            {
                await _photoService.DeletePhotoAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}