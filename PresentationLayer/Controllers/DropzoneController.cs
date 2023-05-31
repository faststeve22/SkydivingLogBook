﻿using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Logbook.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropzoneController : ControllerBase
    {
        private readonly IDropzoneService _dropzoneService;

        public DropzoneController(IDropzoneService dropzoneService)
        {
            _dropzoneService = dropzoneService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dropzoneService.GetDropzoneList());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dropzoneService.GetDropzoneById(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] DropzoneDTO dto)
        {
                _dropzoneService.AddDropzone(dto);
                return Ok();
        }

        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody] DropzoneDTO dto)
        {
                _dropzoneService.UpdateDropzone(dto);
                return Ok();
        }

        [Authorize]
        [HttpDelete("{dropzoneId}")]
        public IActionResult Delete(int dropzoneId)
        {
            _dropzoneService.DeleteDropzone(dropzoneId);
            return Ok();
        }
    }
}
