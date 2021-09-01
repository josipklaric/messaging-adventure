using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagingAdventure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessagingAdventure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiCallsController : ControllerBase
    {
        private readonly MessagingAdventureRepository repository;

        public ApiCallsController(MessagingAdventureRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ApiCall>> GetCalls()
        {
            IEnumerable<ApiCall> apiCalls = Enumerable.Empty<ApiCall>();

            using (var db = new MessagingAdventureContext())
            {
                apiCalls = await db.ApiCalls.OrderByDescending(b => b.Date).ToListAsync();
            }
            
            return apiCalls;
        }
    }
}
