﻿using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface IItemRepo
    {

      
        
        Item GetItemByID(int CompanyID , string ItemCode);
        void Add(Item ObjSave);
        void Update(Item ObjUpdate);
        void Delete(Item ObjDelete);

      
    }
}