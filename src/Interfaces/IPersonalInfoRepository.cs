using System.Threading.Tasks;
using QL.Models;

namespace QL.PersonalInfo.Interfaces
{
    public interface IPersonalInfoRepository
    {
         MyPersonalInfoModel GetPersonalInfo(string name);

        //  string  GetPersonalInfo(string name); // working
    }
    
}