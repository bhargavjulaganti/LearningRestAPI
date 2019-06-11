using System.Threading.Tasks;
using QL.PersonalInfo.Interfaces;
using QL.Models;

namespace QL.Repository
{
    public class PersonalInfoRepository : IPersonalInfoRepository
    {

        public MyPersonalInfoModel GetPersonalInfo(string name)
        {
            return new MyPersonalInfoModel
            {
                Name = name,
                Age = (int)name[0]
            };
        }

    }
}