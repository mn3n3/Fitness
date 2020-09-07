using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGroupRepo Group { get; set; }
        public IItemRepo Item { get; set; }
        public INationalityRepo Nationality { get; set; }
        public IJobRepo Job { get; set; }
        public IPlaceOfBirthRepo PlaceOfBirth { get; set; }
        public ICustomerCompanyRepo CustomerCompany { get; set; }
        public ITrainerRepo Trainer { get; set; }
        public ISourceRepo Source { get; set; }
        public ISubscriberRepo Subscriber { get; set; }
        public ISubscriptionRepo Subscription { get; set; }
        public IVisitorRepo Visitor { get; set; }
        public IUserRepo User { get; set; }
        public INativeSqlRepo NativeSql { get; set; }
        public ICompanyRepo Company { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Group = new GroupRepo(_context);
            Item = new ItemRepo(_context);
            Nationality = new NationalityRepo(_context);
            Job = new JobRepo(_context);
            PlaceOfBirth = new PlaceOfBirthRepo(_context);
            CustomerCompany = new CustomerCompanyRepo(_context);
            Trainer = new TrainerRepo(_context);
            Source = new SourceRepo(_context);
            Subscriber = new SubscriberRepo(_context);
            Subscription = new SubscriptionRepo(_context);
            Visitor = new VisitorRepo(_context);
            User = new UserRepo(_context);
            NativeSql = new NativeSqlRepo(_context);
            Company = new CompanyRepo(_context);
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}