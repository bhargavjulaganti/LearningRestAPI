using System.Threading.Tasks;
using QL.Models;

namespace QL.PersonalInfo.Interfaces
{
    public interface IPersonalInfoRepository
    {
        Task<MyPersonalInfoModel> GetPersonalInfo(string name);
    }    
}