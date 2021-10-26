using MailingEvaluationAPI.Features.MailingList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingEvaluationAPI.Controllers
{
    [Route("api/mailing")]
    [ApiController]
    public class MailingListController : ControllerBase
    {
        IMediator _mediator;
        public MailingListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/mailing/getSubscribers
        [HttpGet("getSubscribers")]
        public IActionResult Get([FromQuery] GetEmailSubscribers.Query request)
        {
            var result = _mediator.Send(request);
            return Ok(result);
        }

        // POST api/mailing/addSubscriber
        [HttpPost("addSubscriber")]
        public IActionResult Post([FromBody] AddEmailSubscriber.Command request)
        {
            var result = _mediator.Send(request);
            return Ok(result);
        }
    }
}
