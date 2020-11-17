using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestPermission.Database
{
    public class RequestPermissionDesingTimeDbContextFactory : IDesignTimeDbContextFactory<RequestPermissionContext>
    {
        public RequestPermissionContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RequestPermissionContext>();
            string connectionString = "Data Source=DESKTOP-31A9CQK\\VBMSSQLSERVER;Initial Catalog=RequestPermission;Integrated Security=True";
            builder.UseSqlServer(connectionString ?? throw new Exception("connection string empty"));

            return new RequestPermissionContext(builder.Options);
        }

       
    }
}
