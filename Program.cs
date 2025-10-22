using CMCS.Models;

namespace CMCS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Seed some test claims
            SeedClaims();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Make sure static files are served
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        // Method to seed some test claims
        private static void SeedClaims()
        {
            if (!ClaimData.Claims.Any())
            {
                ClaimData.Claims.AddRange(new List<ClaimViewModel>
                {
                    new ClaimViewModel
                    {
                        LecturerName = "Dr. Smith",
                        ClaimMonth = "October",
                        ContractType = "Part-Time",
                        HoursWorked = 40,
                        HourlyRate = 250,
                        TotalAmount = 40 * 250,
                        Notes = "October teaching hours",
                        Status = "Submitted"
                    },
                    new ClaimViewModel
                    {
                        LecturerName = "Prof. Johnson",
                        ClaimMonth = "September",
                        ContractType = "Full-Time",
                        HoursWorked = 160,
                        HourlyRate = 200,
                        TotalAmount = 160 * 200,
                        Notes = "September contract hours",
                        Status = "Submitted"
                    },
                    new ClaimViewModel
                    {
                        LecturerName = "Dr. Williams",
                        ClaimMonth = "August",
                        ContractType = "Part-Time",
                        HoursWorked = 80,
                        HourlyRate = 180,
                        TotalAmount = 80 * 180,
                        Notes = "August teaching hours",
                        Status = "Submitted"
                    }
                });
            }
        }
    }
}
