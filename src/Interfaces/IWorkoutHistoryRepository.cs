using System.Threading.Tasks;
using QL.Models;
using System.Collections.Generic;

namespace QL.PersonalInfo.Interfaces
{
    public interface IWorkoutHistoryRepository
    {
        Task<List<WorkoutHistoryModel>> GetWorkoutHistory(string name);
        Task PostWorkOut(WorkoutHistoryModel workoutModel);
    }    
}