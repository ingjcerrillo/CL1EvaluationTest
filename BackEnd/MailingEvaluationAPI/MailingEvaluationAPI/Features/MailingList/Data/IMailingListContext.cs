using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingEvaluationAPI.Features.MailingList.Data
{
    public interface IMailingListContext
    {
        public DbSet<EmailSubscriber> EmailSubscribers { get; set; }

        int SaveChanges();
    }
}
