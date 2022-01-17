﻿using Core.Entities.Concrete;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        //IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        //IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email); // kullanıcı daha once kayit oldu mu
        //IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
