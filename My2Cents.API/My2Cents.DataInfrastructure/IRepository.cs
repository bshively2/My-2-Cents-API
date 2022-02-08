using Microsoft.AspNetCore.Mvc;
using My2Cents.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.DataInfrastructure
{
    public interface IRepository
    {
        Task<IActionResult> GetUserInfo(int userId);
    }
}
