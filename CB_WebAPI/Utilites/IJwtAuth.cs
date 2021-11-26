using CB_DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB_WebAPI.Utilites
{
 public interface IJwtAuth
    {
         string Authentication(UsersRequest obj);
    }
}
