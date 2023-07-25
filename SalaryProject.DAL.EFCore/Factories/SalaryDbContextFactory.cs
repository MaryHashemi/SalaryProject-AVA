using Microsoft.EntityFrameworkCore;
using SalaryProject.DAL.EFCore.Contexts;

namespace SalaryProject.DAL.EFCore.Factories
{
    public class SalaryDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _optionsAction;

        public SalaryDbContextFactory(Action<DbContextOptionsBuilder> optionsAction)
        {
            _optionsAction = optionsAction;
        }

        public SalaryDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SalaryDbContext>();
            _optionsAction(optionsBuilder);
            return new SalaryDbContext(optionsBuilder.Options);
        }
    }
}
