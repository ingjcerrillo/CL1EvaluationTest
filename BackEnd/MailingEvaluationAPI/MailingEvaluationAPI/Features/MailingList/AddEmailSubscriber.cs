using MailingEvaluationAPI.Features.MailingList.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MailingEvaluationAPI.Features.MailingList
{
    public static class AddEmailSubscriber
    {
        public class Command : IRequest<Response>
        {
            public string Email { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response>
        {
            IMailingListContext _db;
            public Handler(IMailingListContext db)
            {
                _db = db;
            }

            public Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                return Task.FromResult(
                    SaveSubscriber(request.Email, request.LastName, request.FirstName)
                    );
            }

            private Response SaveSubscriber(string email, string lastName, string firstName)
            {
                //For larger mapping its recommended to use a library like Autofac.
                EmailSubscriber newEmailSubscriber = new EmailSubscriber
                {
                    Email = email,
                    LastName = lastName,
                    FirstName = firstName
                };

                try
                {
                    _db.EmailSubscribers.Add(newEmailSubscriber);
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return new Response
                    {
                        Success = false,
                        Message = ex.Message
                    };
                }

                return new Response
                {
                    Success = true,
                    Message = $"Succesfully added {email} to Mailing List."
                };
            }
        }

        public class Response
        {
            public string Message { get; set; }
            public bool Success { get; set; }
        }
    }
}
