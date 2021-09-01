using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MessagingAdventure.Data
{
    public class MessagingAdventureRepository
    {
        private readonly MessagingAdventureContext dbContext;

        public MessagingAdventureRepository(MessagingAdventureContext context)
        {
            this.dbContext = context;
        }

        public async Task<IEnumerable<ApiCall>> GetAllApiCalls()
        {
            return await this.dbContext.ApiCalls.OrderByDescending(r => r.Date).ToListAsync();
        }

        public async Task<bool> SaveApiCall(ApiCall apiCall)
        {
            ApiCall existingEntry = null;
            if (apiCall != null)
            {
                existingEntry = dbContext.ApiCalls.FirstOrDefault(r => r.Id == apiCall.Id);
            }

            if (existingEntry == null)
            {
                this.dbContext.Add(apiCall);
            }
            else
            {
                existingEntry.Id = apiCall.Id;
                existingEntry.Content = apiCall.Content;
                existingEntry.Date = apiCall.Date;
            }

            var affected = await this.dbContext.SaveChangesAsync();

            return affected > 0;
        }
    }
}
