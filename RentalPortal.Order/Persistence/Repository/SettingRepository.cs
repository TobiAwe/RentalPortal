﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentalPortal.Order.Data;
using RentalPortal.Order.Entities;
using RentalPortal.Order.Persistence.Repository.Interfaces;

namespace RentalPortal.Order.Persistence.Repository
{
    public class SettingRepository : Repository<Setting, EfDbContext>, ISettingRepository
    {
        public SettingRepository(EfDbContext context) : base(context)
        {
        }

        public string GetSettingsAsync(string name)
        {
            var data = Context.Settings.FirstOrDefault(x=>x.Name==name);
            if (data != null) return data.Value;
            //it shouldn't get here all things being equal
            return "1";
        }
    }


}
