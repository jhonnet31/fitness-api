using Microsoft.AspNetCore.Mvc;
using Presentation.ModelBinders;
using Service.Contracts;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/muscularGroup")]
    [ApiController]
    public class MuscularGroupController:ControllerBase
    {
        private IServiceManager _service;

        public MuscularGroupController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("{id:int}", Name = "MuscularGroupById")]
        public IActionResult GetMuscularGroup(int id) {
            var muscularGroup = _service.MuscularGroupService.GetMuscularGroup(id, false);
            return Ok(muscularGroup);
        }

        [HttpPost("create")]
        public IActionResult CreateMuscularGroup([FromBody] MuscularGroupForCreationDto muscularGroup) {
            if (muscularGroup is null)
                return BadRequest($"{nameof(MuscularGroupForCreationDto)} object cannot be null.");
            var muscularGroupCreated=_service.MuscularGroupService.CreateMuscularGroup(muscularGroup);
            return CreatedAtRoute("MuscularGroupById", new { id = muscularGroupCreated.Id }, muscularGroupCreated);
        }

        [HttpGet("collection/({ids})", Name = "MuscularGroupCollection")]
        public IActionResult GetByIds([ModelBinder(BinderType =typeof(ArrayModelBinder))] IEnumerable<int> ids) { 
            var records=_service.MuscularGroupService.GetByIds(ids, false);
            return Ok(records);
        }

        [HttpPost("collection")]
        public IActionResult CreateMuscularGroupCollection([FromBody] IEnumerable<MuscularGroupForCreationDto> collection) {
            var result = _service.MuscularGroupService.AddMuscularGroupCollection(collection);
            return CreatedAtRoute("MuscularGroupCollection", new { result.ids }, result.muscularGroups);
        }

    }
}
