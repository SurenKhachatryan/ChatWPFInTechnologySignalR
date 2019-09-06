using System.Collections.Generic;
using DAL.Models;

namespace BLL.Services.ErrorServices
{
    public interface IErrorService
    {
        List<Error> GetErrors();
    }
}