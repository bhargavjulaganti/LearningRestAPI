using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QL.PersonalInfo.Interfaces;
using QL.Models;

namespace mycode.Controllers
{
    [Route("api/[controller]")]

    public class PersonalInfoController : ControllerBase
    {

        private readonly IPersonalInfoRepository personalInfoRepository;

        public PersonalInfoController(IPersonalInfoRepository personalInfoRepository)
        {
            this.personalInfoRepository = personalInfoRepository;
        }

        [HttpGet("{id}")]
        public   ActionResult<MyPersonalInfoModel> Get(string id)
        {
            return  personalInfoRepository.GetPersonalInfo(id);
        }

    }
   
}
