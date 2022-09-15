using Entities.Models;
using System.Linq.Expressions;

namespace Contracts
{
    public interface IMuscularGroupRepository
    {

        MuscularGroup GetMuscularGroup(int id,bool trackChanges);
        IEnumerable<MuscularGroup> GetAllMuscularGroups(bool trackChanges);
        void CreateMuscularGroup(MuscularGroup muscularGroup );
        IEnumerable<MuscularGroup> GetByIds(IEnumerable<int> ids,bool trackChanges);
        
    }
}