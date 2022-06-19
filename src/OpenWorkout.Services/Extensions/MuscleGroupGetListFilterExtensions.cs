using OpenWorkout.Entities;

namespace OpenWorkout.Services.Extensions
{
    internal static class MuscleGroupGetListFilterExtensions
    {
        internal static IQueryable<MuscleGroup> SetFilter(this IQueryable<MuscleGroup> query, string? muscleGroupName)
        {
            if (!string.IsNullOrEmpty(muscleGroupName))
                query = query.Where(m => m.MuscleGroupName.Contains(muscleGroupName));

            return query;
        }
    }
}
