using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WildBillPnw.SelahCreek.Models;
using WildBillPnw.SelahCreek.Queue;

namespace WildBillPnw.SelahCreek.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NetworkIncidentController : ControllerBase
    {
        private readonly ILogger<NetworkIncidentController> _logger;

        private readonly ISendQueue _queueSend;

        public NetworkIncidentController(ILogger<NetworkIncidentController> logger, ISendQueue queueSend)
        {
            _logger = logger;
            _queueSend = queueSend;
        }

        [HttpGet]
        public string Get()
        {
            return "ok.";
        }
    }
}
