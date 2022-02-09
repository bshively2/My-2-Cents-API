using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.DataInfrastructure
{
    public interface IRepository
    {
        Task<UserProfile> GetUserInfo(int userId);
        Task<UserProfile> PostNewUserInfo(UserProfile profile);
        Task<UserProfile> PutUserInfo(int UserId, UserProfile profile);
    }
}
