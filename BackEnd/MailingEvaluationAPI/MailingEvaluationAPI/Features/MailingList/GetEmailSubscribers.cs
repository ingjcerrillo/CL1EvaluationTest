using MailingEvaluationAPI.Features.MailingList.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MailingEvaluationAPI.Features.MailingList
{
    public static class GetEmailSubscribers
    {
        public class Query : IRequest<List<EmailSubscriber>>
        {
            public string LastName { get; set; }
            public bool SortAscending { get; set; } = true;
        }

        public class QueryHandler : IRequestHandler<Query, List<EmailSubscriber>>
        {
            IMailingListContext _db;
            public QueryHandler(IMailingListContext db)
            {
                _db = db;
            }

            public Task<List<EmailSubscriber>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Task.FromResult(
                    this.GetEmailSubscribers(request.LastName, request.SortAscending)
                    );
            }

            List<EmailSubscriber> GetEmailSubscribers(string lastName, bool sortAscending)
            {
                List<EmailSubscriber> subscribers;

                if (String.IsNullOrEmpty(lastName))
                    subscribers = _db.EmailSubscribers.ToList();
                else
                    subscribers = _db.EmailSubscribers.Where(es => es.LastName == lastName).ToList();

                if (sortAscending)
                    subscribers = subscribers.OrderBy(es => es.LastName).ThenBy(es => es.FirstName).ToList();
                else
                    subscribers = subscribers.OrderByDescending(es => es.LastName).ThenByDescending(es => es.FirstName).ToList();

                return subscribers;
            }
        }

    }
}
