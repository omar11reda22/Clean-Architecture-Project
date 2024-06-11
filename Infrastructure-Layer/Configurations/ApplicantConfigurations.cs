using Domain_Layer.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Configurations
{
    public class ApplicantConfigurations : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.HasKey(s => s.ID);
            builder.HasOne(s => s.university).WithMany(s => s.Applicants).HasForeignKey(s => s.UNV_ID);
            builder.HasOne(s => s.major).WithMany(s => s.Applicants).HasForeignKey(s => s.MJR_ID);
            builder.Property(s => s.Message).HasMaxLength(750);
            builder.Property(s => s.Message2).HasMaxLength(500);
            builder.Property(s => s.Message3).HasMaxLength(500);

        }
    }
}
