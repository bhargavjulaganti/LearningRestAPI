using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QL.PersonalInfo.Interfaces;
using QL.Models;

namespace mycode.Controllers
{
    [Route("api/[Controller]")]
    public class WorkoutHistoryController : ControllerBase
    {

        private readonly IWorkoutHistoryRepository personalInfoRepository;

        public WorkoutHistoryController(IWorkoutHistoryRepository personalInfoRepository)
        {
            this.personalInfoRepository = personalInfoRepository;
        }

        [HttpGet("{WorkoutType}")]
        public async Task<List<WorkoutHistoryModel>> Get(string WorkoutType)
        {
            return await personalInfoRepository.GetWorkoutHistory(WorkoutType);
        }

    }

}
