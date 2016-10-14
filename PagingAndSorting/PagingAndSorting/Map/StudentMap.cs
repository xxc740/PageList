using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using PagingAndSorting.Models;

namespace PagingAndSorting.Map
{
    public class StudentMap:EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            //配置主键
            this.HasKey(s => s.ID);

            //把ID列设置为自增列
            this.Property(s => s.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //配置列
            this.Property(s => s.Name).HasMaxLength(100).IsRequired();
            this.Property(s => s.Sex).HasMaxLength(2).IsRequired();
            this.Property(s => s.Age).IsRequired();
            this.Property(s => s.Email).HasMaxLength(100).IsRequired();
        }
    }
}