namespace Service.Contracts
{
    public interface IServiceManager
    {
        public IMuscularGroupService MuscularGroupService { get; }
        public IExerciseService ExerciseService { get; }
    }
}