using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MuscularGroupRepository :RepositoryBase<MuscularGroup>, IMuscularGroupRepository
    {


        public MuscularGroupRepository(RepositoryContext repository):base(repository)
        {

        }

    
        public void CreateMuscularGroup(MuscularGroup muscularGroup) =>
            Create(muscularGroup);


        public IEnumerable<MuscularGroup> GetAllMuscularGroups(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(x=>x.Name).ToList();

 
        public MuscularGroup GetMuscularGroup(int id, bool trackChanges) =>
            FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();

        public IEnumerable<MuscularGroup> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges).OrderBy(x => x.Name).ToList();

    }
}
