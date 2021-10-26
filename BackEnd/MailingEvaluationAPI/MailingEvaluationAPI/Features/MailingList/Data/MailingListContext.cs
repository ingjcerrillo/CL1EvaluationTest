using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingEvaluationAPI.Features.MailingList.Data
{
    public class MailingListContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseInMemoryDatabase("ml");
            }
        }
    }
}
