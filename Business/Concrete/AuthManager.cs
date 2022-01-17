using Business.Abstract;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
