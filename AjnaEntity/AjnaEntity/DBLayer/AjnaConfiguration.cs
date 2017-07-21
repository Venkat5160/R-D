using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;

namespace AjnaEntity.DBLayer
{
    public class AjnaConfiguration:DbConfiguration
    {
        public AjnaConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            DbInterception.Add(new AjnainterceptorLogging());
            DbInterception.Add(new AjnaInterceptorTransientErrors());

        }
    }
}