using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/muscularGroup/{muscleId}/exercises")]
    [ApiController]
    public  class ExerciseController:ControllerBase
    {
        private readonly IServiceManager _service;

       
        public ExerciseController(IServiceManager service) => _service = service;

        [HttpGet(Name ="GetAll")]
        public IActionResult GetAllExercises() {
            //throw new NotFoundException("test error");
            var exercises = _service.ExerciseService.GetAllExercises(trackChanges:false);
            return Ok(exercises);
        }

        [HttpGet("{id:int}",Name ="ExerciseById")]
        public IActionResult GetExercise(int id) {
            var exercise = _service.ExerciseService.GetExercise(id,false);
            return Ok(exercise);
        }

        [HttpPost]
        public IActionResult CreateExercise([FromBody] ExerciseForCreationDto exercise) {
            if (exercise is null)
                return BadRequest($"{nameof(ExerciseForCreationDto)} object is null");
            var exerciseCreated=_service.ExerciseService.AddExercise(exercise);
            return CreatedAtRoute("ExerciseById", new { Id = exerciseCreated.Id}, exerciseCreated);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteExercise(int muscleId, int id) {
            _service.ExerciseService.DeleteExercise(muscleId, id, false);
            return NoContent();
        }
        
    }
}