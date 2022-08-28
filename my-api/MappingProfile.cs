using AutoMapper;
using Entities.Models;
using Shared.DTOs;

namespace my_api
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Exercise, ExerciseDto>();
            CreateMap<ExerciseForCreationDto, Exercise>();
            CreateMap<MuscularGroup, MuscularGroupDto>();
            CreateMap<MuscularGroupForCreationDto, MuscularGroup>();
        }
    }
}
