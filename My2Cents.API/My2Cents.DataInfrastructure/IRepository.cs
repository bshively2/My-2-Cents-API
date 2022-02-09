using Microsoft.AspNetCore.Mvc;
using My2Cents.DataInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.DataInfrastructure
{
    public interface IRepository
    {
        Task<ActionResult<IEnumerable<UserProfileDto>>> GetUserInfo(int userId);
        Task<UserProfile> PostNewUserInfo(UserProfile profile);
        Task<UserProfile> PutUserInfo(int UserId, UserProfileDto profile);
        Task<ActionResult<IEnumerable<AccountListDto>>> GetUserAccounts(int userId);
    }
}
