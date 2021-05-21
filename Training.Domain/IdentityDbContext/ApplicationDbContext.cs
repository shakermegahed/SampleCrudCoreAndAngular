using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Training.Domain.ViewModel;

namespace Training.Domain.Entities
{
    public class ApplicationDbContext : IdentityDbContext<RegistrationViewModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<RegistrationViewModel> RegistrationViewModel { get; set; }
    }
}