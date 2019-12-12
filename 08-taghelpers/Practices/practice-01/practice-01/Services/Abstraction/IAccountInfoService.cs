﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_01.Models;

namespace practice_01.Services.Abstraction
{
    public interface IAccountInfoService
    {
        public IEnumerable<AccountInfo> GetAccountInfo();
        void AddAccountInfo(AccountInfo contact);
    }
}
