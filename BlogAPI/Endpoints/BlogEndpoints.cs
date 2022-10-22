using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Endpoints
{

    public class BlogEndpoints
    {
        [Route("/")]
        public int Get()
        {
            
            return 0;
        }
    }
}
