using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosDBv1.Services.Utility
{
    public class ClaimService
    {
        public string GetUserCampus(HttpContext ctx)
        {
            var claim = ctx?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Locality);
            if (claim != null)
            {
                return claim.Value;
            }

            return string.Empty;
        }
    }
}
