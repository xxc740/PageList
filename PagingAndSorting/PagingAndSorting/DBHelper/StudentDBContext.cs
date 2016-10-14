using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PagingAndSorting.Map;

namespace PagingAndSorting.DBHelper
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext() : base("name=DBConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //只有一个实体，不用反射来做，直接添加单个实体的配置
            modelBuilder.Configurations.Add(new StudentMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}