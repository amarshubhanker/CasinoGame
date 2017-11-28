﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Casino.EntityDataModel.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class UserDBEntities : DbContext
    {
        public UserDBEntities()
            : base("name=UserDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CasinoDB> CasinoDBs { get; set; }
    
        public virtual ObjectResult<CasinoDB> SearchCustomers(string name, string email, string contactNumber)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var contactNumberParameter = contactNumber != null ?
                new ObjectParameter("ContactNumber", contactNumber) :
                new ObjectParameter("ContactNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CasinoDB>("SearchCustomers", nameParameter, emailParameter, contactNumberParameter);
        }
    
        public virtual ObjectResult<CasinoDB> SearchCustomers(string name, string email, string contactNumber, MergeOption mergeOption)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var contactNumberParameter = contactNumber != null ?
                new ObjectParameter("ContactNumber", contactNumber) :
                new ObjectParameter("ContactNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CasinoDB>("SearchCustomers", mergeOption, nameParameter, emailParameter, contactNumberParameter);
        }
    }
}
