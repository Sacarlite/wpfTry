using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfTry.Viev.Interface;

namespace wpfTry.Services.AtorizationService.@interface
{

    public interface IAuthorizationFactory
    {
        IWindow CreateAutorizationindow();
    }

}
