using Xunit;
using FluentAssertions;
using CleanArchMvc.Infra.Data.Repositories;
using CleanArchMvc.Infra.Data.Tests.TestHelpers;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Tests.Repositories
{
    public class CategoryRepositoryTests : IDisposable
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly ApplicationDbContext _context;

        public CategoryRepositoryTests()
        {
            _context = TestDbContextFactory.CreateInMemoryContext();
            _categoryRepository = new CategoryRepository(_context);
        }

        [Fact]
        public async Task Create_ShouldAddCategoryToDatabase()
        {
            // Arrange
            var category = TestDataBuilder.CreateValidCategory("Electronics");

            // Act
            var result = await _categoryRepository.Create(category);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("Electronics");
            result.Id.Should().BeGreaterThan(0);

            var categoryInDb = await _context.Categories.FindAsync(result.Id);
            categoryInDb.Should().NotBeNull();
            categoryInDb!.Name.Should().Be("Electronics");
        }

        [Fact]
        public async Task GetById_WithValidId_ShouldReturnCategory()
        {
            // Arrange
            var category = TestDataBuilder.CreateValidCategory("Books");
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            // Act
            var result = await _categoryRepository.GetById(category.Id);

            // Assert
            result.Should().NotBeNull();
            result!.Name.Should().Be("Books");
            result.Id.Should().Be(category.Id);
        }

        [Fact]
        public async Task GetById_WithInvalidId_ShouldReturnNull()
        {
            // Act
            var result = await _categoryRepository.GetById(999);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetCategories_ShouldReturnAllCategories()
        {
            // Arrange
            var category1 = TestDataBuilder.CreateValidCategory("Category 1");
            var category2 = TestDataBuilder.CreateValidCategory("Category 2");
            var category3 = TestDataBuilder.CreateValidCategory("Category 3");

            await _context.Categories.AddRangeAsync(category1, category2, category3);
            await _context.SaveChangesAsync();

            // Act
            var result = await _categoryRepository.GetCatories();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
            result.Should().Contain(c => c.Name == "Category 1");
            result.Should().Contain(c => c.Name == "Category 2");
            result.Should().Contain(c => c.Name == "Category 3");
        }

        [Fact]
        public async Task GetCategories_WithEmptyDatabase_ShouldReturnEmptyCollection()
        {
            // Act
            var result = await _categoryRepository.GetCatories();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Update_ShouldModifyCategoryInDatabase()
        {
            // Arrange
            var category = TestDataBuilder.CreateValidCategory("Original Name");
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            category.Update("Updated Name");

            // Act
            var result = await _categoryRepository.Update(category);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("Updated Name");

            var categoryInDb = await _context.Categories.FindAsync(category.Id);
            categoryInDb.Should().NotBeNull();
            categoryInDb!.Name.Should().Be("Updated Name");
        }

        [Fact]
        public async Task Remove_ShouldDeleteCategoryFromDatabase()
        {
            // Arrange
            var category = TestDataBuilder.CreateValidCategory("To Be Deleted");
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            // Act
            var result = await _categoryRepository.Remove(category);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("To Be Deleted");

            var categoryInDb = await _context.Categories.FindAsync(category.Id);
            categoryInDb.Should().BeNull();
        }

        [Fact]
        public async Task Remove_NonExistentCategory_ShouldThrowDbUpdateConcurrencyException()
        {
            // Arrange
            var category = TestDataBuilder.CreateValidCategoryWithId(999, "Non Existent");

            // Act & Assert
            var exception = await Record.ExceptionAsync(async () => await _categoryRepository.Remove(category));
            exception.Should().NotBeNull();
            exception.Should().BeOfType<Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException>();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}