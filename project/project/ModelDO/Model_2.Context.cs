﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project.ModelDO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities_Consulta : DbContext
    {
        public Entities_Consulta()
            : base("name=Entities_Consulta")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<viewAccesorios2_Result> viewAccesorios2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewAccesorios2_Result>("viewAccesorios2");
        }
    
        public virtual ObjectResult<viewCase_Result> viewCase()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewCase_Result>("viewCase");
        }
    
        public virtual ObjectResult<viewDiscoDuro_Result> viewDiscoDuro()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewDiscoDuro_Result>("viewDiscoDuro");
        }
    
        public virtual ObjectResult<viewFuentePoder_Result> viewFuentePoder()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewFuentePoder_Result>("viewFuentePoder");
        }
    
        public virtual ObjectResult<viewMonitor_Result> viewMonitor()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewMonitor_Result>("viewMonitor");
        }
    
        public virtual ObjectResult<viewPerifericos_Result> viewPerifericos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewPerifericos_Result>("viewPerifericos");
        }
    
        public virtual ObjectResult<viewProcesador_Result> viewProcesador()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewProcesador_Result>("viewProcesador");
        }
    
        public virtual ObjectResult<viewProcesadorAMD_Result> viewProcesadorAMD()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewProcesadorAMD_Result>("viewProcesadorAMD");
        }
    
        public virtual ObjectResult<viewProcesadorIntel_Result> viewProcesadorIntel()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewProcesadorIntel_Result>("viewProcesadorIntel");
        }
    
        public virtual ObjectResult<viewRam_Result> viewRam()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewRam_Result>("viewRam");
        }
    
        public virtual ObjectResult<viewTarjetaMadre_Result> viewTarjetaMadre()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewTarjetaMadre_Result>("viewTarjetaMadre");
        }
    
        public virtual ObjectResult<viewTarjetaVideo_Result> viewTarjetaVideo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewTarjetaVideo_Result>("viewTarjetaVideo");
        }
    
        public virtual ObjectResult<viewDetailsProducto_Result> viewDetailsProducto(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewDetailsProducto_Result>("viewDetailsProducto", iDParameter);
        }
    
        public virtual ObjectResult<viewDetailsProducto2_Result> viewDetailsProducto2(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewDetailsProducto2_Result>("viewDetailsProducto2", iDParameter);
        }
    
        public virtual ObjectResult<viewDetailsProfile_Result> viewDetailsProfile(string iDUser)
        {
            var iDUserParameter = iDUser != null ?
                new ObjectParameter("IDUser", iDUser) :
                new ObjectParameter("IDUser", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewDetailsProfile_Result>("viewDetailsProfile", iDUserParameter);
        }
    }
}
