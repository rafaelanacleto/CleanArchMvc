using Xunit;
using FluentAssertions;
using CleanArchMvc.Infra.Data.Repositories;
using CleanArchMvc.Infra.Data.Tests.TestHelpers;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Tests.Repositories
{
    public class ProductRepositoryTests : IDisposable
    {
        private readonly ProdutctRepository _productRepository;
        private readonly ApplicationDbContext _context;

        public ProductRepositoryTests()
        {
            _context = TestDbContextFactory.CreateInMemoryContext();
            _productRepository = new ProdutctRepository(_context);
        }

        [Fact]
        public async Task CreateAsync_ShouldAddProductToDatabase()
        {
            // Arrange
            var category = TestDataBuilder.CreateValidCategory("Electronics");
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            var product = TestDataBuilder.CreateValidProduct("Smartphone", "Latest model", 999.99m, 50, "phone.jpg");
            product.Update("Smartphone", "Latest model", 999.99m, 50, "phone.jpg", category.Id);

            // Act
            var result = await _productRepository.CreateAsync(product);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("Smartphone");

            Assert.Equal(999.99m, result.Price);
            result.Price.Should().Be(999.99m);
            result.Stock.Should().Be(50);
            
            result.Id.Should().BeGreaterThan(0);

            var productInDb = await _context.Products.FindAsync(result.Id);
            productInDb.Should().NotBeNull();
            productInDb!.Name.Should().Be("Smartphone");
        }

        [Fact]
        public async Task GetByIdAsync_WithValidId_ShouldReturnProduct()
        {
            // Arrange
            var category = TestDataBuilder.CreateValidCategory("Books");
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            var product = TestDataBuilder.CreateValidProduct("C# Programming", "Learn C#", 49.99m, 25, "book.jpg");
            product.Update("C# Programming", "Learn C#", 49.99m, 25, "book.jpg", category.Id);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            // Act
            var result = await _productRepository.GetByIdAsync(product.Id);

            // Assert
            result.Should().NotBeNull();
            result!.Name.Should().Be("C# Programming");
            result.Price.Should().Be(49.99m);
            result.Id.Should().Be(product.Id);
        }

        [Fact]
        public async Task GetByIdAsync_WithInvalidId_ShouldReturnNull()
        {
            // Act
            var result = await _productRepository.GetByIdAsync(999);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetProductsAsync_ShouldReturnAllProductsWithCategories()
        {
            // Arrange
            var category = TestDataBuilder.CreateValidCategory("Electronics");
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            var product1 = TestDataBuilder.CreateValidProduct("Product 1", "Description 1", 10.0m, 5, "img1.jpg");
            var product2 = TestDataBuilder.CreateValidProduct("Product 2", "Description 2", 20.0m, 10, "img2.jpg");
            
            product1.Update("Product 1", "Description 1", 10.0m, 5, "img1.jpg", category.Id);
            product2.Update("Product 2", "Description 2", 20.0m, 10, "img2.jpg", category.Id);

            await _context.Products.AddRangeAsync(product1, product2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _productRepository.GetProductsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().Contain(p => p.Name == "Product 1");
            result.Should().Contain(p => p.Name == "Product 2");
            
            // Verify that categories are included
            result.All(p => p.Category != null).Should().BeTrue();
        }

        [Fact]
        public async Task GetProductsAsync_WithEmptyDatabase_ShouldReturnEmptyCollection()
        {
            // Act
            var result = await _productRepository.GetProductsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetProductCategoryAsync_WithValidId_ShouldReturnProductWithCategory()
        {
            // Arrange
            var category = TestDataBuilder.CreateValidCategory("Sports");
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            var product = TestDataBuilder.CreateValidProduct("Soccer Ball", "Professional ball", 29.99m, 15, "ball.jpg");
            product.Update("Soccer Ball", "Professional ball", 29.99m, 15, "ball.jpg", category.Id);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            // Act
            var result = await _productRepository.GetProductCategoryAsync(product.Id);

            // Assert
            result.Should().NotBeNull();
            result!.Name.Should().Be("Soccer Ball");
            result.Category.Should().NotBeNull();
            result.Category!.Name.Should().Be("Sports");
        }

        [Fact]
        public async Task GetProductCategoryAsync_WithInvalidId_ShouldReturnNull()
        {
            // Act
            var result = await _productRepository.GetProductCategoryAsync(999);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task UpdateAsync_ShouldModifyProductInDatabase()
        {
            // Arrange
            var category = TestDataBuilder.CreateValidCategory("Home");
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            var product = TestDataBuilder.CreateValidProduct("Original Product", "Original Description", 100.0m, 20, "orig.jpg");
            product.Update("Original Product", "Original Description", 100.0m, 20, "orig.jpg", category.Id);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            product.Update("Updated Product", "Updated Description", 150.0m, 30, "updated.jpg", category.Id);

            // Act
            var result = await _productRepository.UpdateAsync(product);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("Updated Product");
            result.Description.Should().Be("Updated Description");
            result.Price.Should().Be(150.0m);

            var productInDb = await _context.Products.FindAsync(product.Id);
            productInDb.Should().NotBeNull();
            productInDb!.Name.Should().Be("Updated Product");
        }

        [Fact]
        public async Task RemoveAsync_ShouldDeleteProductFromDatabase()
        {
            // Arrange
            var category = TestDataBuilder.CreateValidCategory("Test Category");
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            var product = TestDataBuilder.CreateValidProduct("To Be Deleted", "Will be removed", 25.0m, 5, "delete.jpg");
            product.Update("To Be Deleted", "Will be removed", 25.0m, 5, "delete.jpg", category.Id);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            // Act
            var result = await _productRepository.RemoveAsync(product);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("To Be Deleted");

            var productInDb = await _context.Products.FindAsync(product.Id);
            productInDb.Should().BeNull();
        }

        [Fact]
        public async Task RemoveAsync_NonExistentProduct_ShouldThrowDbUpdateConcurrencyException()
        {
            // Arrange
            var product = TestDataBuilder.CreateValidProductWithId(999, "Non Existent", "Description", 10.0m, 1, "test.jpg");

            // Act & Assert
            var exception = await Record.ExceptionAsync(async () => await _productRepository.RemoveAsync(product));
            exception.Should().NotBeNull();
            exception.Should().BeOfType<Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException>();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}