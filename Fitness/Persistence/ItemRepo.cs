using Fitness.Models;
using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class ItemRepo : IItemRepo
    {

        private readonly ApplicationDbContext _context;
        public ItemRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public void Add(Item ObjSave)
        {
            _context.Items.Add(ObjSave);
        }

        public void Delete(Item ObjDelete )
        {
            
            var ObjToDelete = _context.Items.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.ItemCode == ObjDelete.ItemCode);
            if (ObjToDelete != null)
            {
                _context.Items.Remove(ObjToDelete);
            }
        }

        

        public Item GetItemByID(int CompanyID , string ItemCode)
        {   
             return _context.Items.FirstOrDefault(m => m.CompanyID == CompanyID && m.ItemCode ==ItemCode);
        }

        public void Update(Item ObjUpdate)
        {
            var ObjToUpdate = _context.Items.SingleOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.ItemCode == ObjUpdate.ItemCode);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.ItemName = ObjUpdate.ItemName;
                ObjToUpdate.ItemPrice = ObjUpdate.ItemPrice;
                ObjToUpdate.ItemCost = ObjUpdate.ItemCost;
                ObjToUpdate.InsDateTime = ObjUpdate.InsDateTime;
                ObjToUpdate.InsUserID = ObjUpdate.InsUserID;
            }
        }
    }
}