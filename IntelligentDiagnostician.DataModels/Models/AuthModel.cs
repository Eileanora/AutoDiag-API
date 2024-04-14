﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentDiagnostician.DataModels.Models
{
    public class AuthModel
    {
        public string Message {  get; set; }    
        public bool IsAuthenticated  { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }   
        public string Token { get; set; }  
        public List<string> Roles { get; set; }

    }
}
