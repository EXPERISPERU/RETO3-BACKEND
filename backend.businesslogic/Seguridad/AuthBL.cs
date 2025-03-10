﻿using backend.businesslogic.Interfaces.Seguridad;
using backend.domain;
using backend.repository.Interfaces.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Seguridad
{
    public class AuthBL : IAuthBL
    {
        IAuthRepository repository;
        public AuthBL(IAuthRepository _repository)
        {
            repository = _repository;
        }

        public async Task<LoginDTO> AuthUser(authLoginDTO authLogin)
        {
            return await repository.AuthUser(authLogin);
        }      
    }
}
