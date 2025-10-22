using Xunit;
using CMCS.Models;
using Xunit;
using CMCS.Models;
using CMCS.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ICClaimsTests
{
    public class ClaimTests
    {
        [Fact]
        public void CalculateTotalAmount_ShouldReturnCorrectValue()
        {
            // Arrange
            var claim = new ClaimViewModel
            {
                HoursWorked = 10,
                HourlyRate = 100m
            };

            // Act
            claim.TotalAmount = claim.HoursWorked * claim.HourlyRate;

            // Assert
            Assert.Equal(1000m, claim.TotalAmount);
        }

        [Fact]
        public void Notes_ShouldBeSavedCorrectly()
        {
            // Arrange
            var claim = new ClaimViewModel
            {
                Notes = "This is an additional note for testing."
            };

            // Act & Assert
            Assert.Equal("This is an additional note for testing.", claim.Notes);
        }

        [Fact]
        public void SupportingFile_ShouldBeSavedWithCorrectPath()
        {
            // Arrange
            var claim = new ClaimViewModel();

            // Simulate file upload
            var fileName = "test.txt";
            var fileContent = "Hello, World!";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(fileContent));
            IFormFile formFile = new FormFile(stream, 0, stream.Length, "file", fileName);

            claim.SupportingFile = formFile;

            // Act
            if (claim.SupportingFile != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + claim.SupportingFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    claim.SupportingFile.CopyTo(fileStream);
                }

                claim.DocumentPath = "/uploads/" + uniqueFileName;
                claim.FileName = uniqueFileName;
            }

            // Assert
            Assert.NotNull(claim.DocumentPath);
            Assert.Contains("uploads", claim.DocumentPath);
            Assert.Equal(claim.FileName, Path.GetFileName(claim.DocumentPath));
        }
    }
}
