using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MessagingAdventure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MessagingAdventure.Controllers
{
    [ApiController]
    [Route("api/[controller]/infobip")]
    public class HooksController: Controller
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<HooksController> logger;
        private readonly MessagingAdventureRepository repository;

        public HooksController(IConfiguration configuration, MessagingAdventureRepository repository)
        {
            this.configuration = configuration;
            this.repository = repository;
        }


        [HttpPost("email-delivery-report")]
        public async Task<IActionResult> ReceiveEmailDeliveryReport([FromBody] string data)
        {
            if (data == null)
                return Content("[No data]");

            var serialized = JsonSerializer.Serialize(data);

            var saveSuccess = await this.repository.SaveApiCall(new ApiCall()
            {
                Endpoint = "email/receive",
                Content = serialized,
                Date = DateTime.Now
            });

            return Content(serialized);
        }

        [HttpPost("sms/receive")]
        public async Task<IActionResult> ReceiveSmsAsync([FromBody] object data)
        {
            if (data == null)
                return Content("[No data]");

            var serialized = JsonSerializer.Serialize(data);

            var saveSuccess = await this.repository.SaveApiCall(new ApiCall()
            {
                Endpoint = "sms/receive",
                Content = serialized,
                Date = DateTime.Now
            });

            return Content(serialized);
        }

        [HttpPost("sms/report")]
        public async Task<IActionResult> SmsReportAsync([FromBody] object report)
        {
            if (report == null)
                return Content("[No data]");

            var serialized = JsonSerializer.Serialize(report);

            var saveSuccess = await this.repository.SaveApiCall(new ApiCall()
            {
                Endpoint = "sms/report",
                Content = serialized,
                Date = DateTime.Now
            });

            return Content(serialized);
        }

        [HttpPost("email/report")]
        public async Task<IActionResult> EmailReportAsync([FromBody] object report)
        {
            if (report == null)
                return Content("[No data]");

            var serialized = JsonSerializer.Serialize(report);

            var saveSuccess = await this.repository.SaveApiCall(new ApiCall()
            {
                Endpoint = "email/report",
                Content = serialized,
                Date = DateTime.Now
            });

            return Content(serialized);
        }
    }
}
