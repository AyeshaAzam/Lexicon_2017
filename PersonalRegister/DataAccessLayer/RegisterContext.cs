using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PersonalRegister.Models;

namespace PersonalRegister.DataAccessLayer
{
    public class RegisterContext : DbContext // inherit from DbContext
    {

        // Contructor
        public RegisterContext() : base("PersonalRegisterDB")
        {

        }

        //property
        public DbSet<Personal> Personals { get; set; }
    }

    

   
}