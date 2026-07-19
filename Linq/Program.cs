using Linq.Services;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository.LoadAllData();
            LinqExercises.PureVsImpure();
            LinqExercises.FunctionalProgramming();
            LinqExercises.Projection();
            LinqExercises.Sorting();
            LinqExercises.Partitioning();
            LinqExercises.Quantifiers();
            LinqExercises.Grouping();
            LinqExercises.JoinOperations();
            LinqExercises.GenerationOperations();
            LinqExercises.DeferredVsImmediate();

        }
    }
}
