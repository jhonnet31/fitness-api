using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MuscularGroupService : IMuscularGroupService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public MuscularGroupService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;   
        }

       

        public MuscularGroupDto CreateMuscularGroup(MuscularGroupForCreationDto muscularGroup) {
            var muscularGroupEntity = _mapper.Map<MuscularGroup>(muscularGroup);

            _repository.muscularGroup.CreateMuscularGroup(muscularGroupEntity);
            _repository.Save();
            return _mapper.Map<MuscularGroupDto>(muscularGroupEntity);
            
        }

        public IEnumerable<MuscularGroupDto> GetByIds(IEnumerable<int> ids, bool trackChanges) {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var records =_repository.muscularGroup.GetByIds(ids, trackChanges);
            if (records.Count() != ids.Count())
                throw new CollectionByBadRequestException();

            return _mapper.Map<IEnumerable<MuscularGroupDto>>(records);
        }


        public MuscularGroupDto GetMuscularGroup(int id, bool trackChanges) { 
            var muscularGroup=_repository.muscularGroup.GetMuscularGroup(id, trackChanges);
            if (muscularGroup is null)
                throw new MuscularGroupNotFound(id);
            var muscularGroupDto = _mapper.Map<MuscularGroupDto>(muscularGroup);
            return muscularGroupDto;
        }

        public (IEnumerable<MuscularGroupDto> muscularGroups, string ids) AddMuscularGroupCollection(IEnumerable<MuscularGroupForCreationDto> muscularCollection)
        {
            if (muscularCollection is null)
                throw new IdParametersBadRequestException();

            var entities= _mapper.Map<IEnumerable<MuscularGroup>>(muscularCollection);

            foreach (var entity in entities)
            {
                _repository.muscularGroup.CreateMuscularGroup(entity);

            }
            _repository.Save();
            return (_mapper.Map<IEnumerable<MuscularGroupDto>>(entities), string.Join(",", entities.Select(x => x.Id)));

        }





    }
}
