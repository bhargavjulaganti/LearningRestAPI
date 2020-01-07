using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QL.PersonalInfo.Interfaces;
using QL.Models;
using Microsoft.AspNetCore.Http;

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


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkoutHistoryModel WorkoutModel)
        {
            await personalInfoRepository.PostWorkOut(WorkoutModel);

            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created);
        }

    }

}
