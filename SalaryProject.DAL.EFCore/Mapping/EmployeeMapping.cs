using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalaryProject.Domain.Models;

namespace SalaryProject.DAL.EFCore.Mapping
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("tbl_employees");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.FirstName, x.LastName, x.SalaryDate}).IsUnique();
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.FirstName).HasColumnName("first_name").IsRequired();
            builder.Property(x => x.LastName).HasColumnName("last_name").IsRequired();
            builder.Property(x => x.DateOfBirth).HasColumnName("birth_date");
            builder.Property(x => x.BasicSalary).HasColumnName("basic_salary").IsRequired();
            builder.Property(x => x.AttractionRight).HasColumnName("attraction_right");
            builder.Property(x => x.CommutingRight).HasColumnName("commuting_right");
            builder.Property(x => x.OvertimeAmount).HasColumnName("overtime_amount");
            builder.Property(x => x.SalaryDate).HasColumnName("salary_date").IsRequired();
        }
    }
}