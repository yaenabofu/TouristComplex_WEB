﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Information_System_MVC.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<ISContext>
    {
        protected override void Seed(ISContext db)
        {
            db.Professions.Add(new Profession { Name = "test", Power = 1 });

            base.Seed(db);
        }
    }
}