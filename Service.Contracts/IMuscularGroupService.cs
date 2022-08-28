using Entities.Models;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMuscularGroupService
    {
        MuscularGroupDto GetMuscularGroup(int id, bool trackChanges);
        MuscularGroupDto CreateMuscularGroup(MuscularGroupForCreationDto muscularGroup);
        IEnumerable<MuscularGroupDto> GetByIds(IEnumerable<int> ids,bool trackChanges);
        (IEnumerable<MuscularGroupDto> muscularGroups, string ids) AddMuscularGroupCollection(IEnumerable<MuscularGroupForCreationDto> muscularCollection);
    }
}
