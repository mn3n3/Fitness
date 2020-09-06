using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface IUnitOfWork
    {
        IGroupRepo Group { get; }
        IItemRepo Item { get; }
        IJobRepo Job { get; }
        IPlaceOfBirthRepo PlaceOfBirth { get; }
        ICustomerCompanyRepo CustomerCompany { get; }
        ITrainerRepo Trainer { get; }
        ISourceRepo Source { get; }
        ISubscriberRepo Subscriber { get; }
        ISubscriptionRepo Subscription { get; }
        IVisitorRepo Visitor { get; }
        void Complete();
    }
}