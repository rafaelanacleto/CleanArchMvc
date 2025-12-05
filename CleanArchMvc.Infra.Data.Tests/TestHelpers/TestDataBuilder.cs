using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Infra.Data.Tests.TestHelpers
{
    public static class TestDataBuilder
    {
        public static Category CreateValidCategory(string name = "Test Category")
        {
            return new Category(name);
        }

        public static Category CreateValidCategoryWithId(int id, string name = "Test Category")
        {
            return new Category(id, name);
        }

        public static Product CreateValidProduct(
            string name = "Test Product",
            string description = "Test Description",
            decimal price = 10.50m,
            int stock = 100,
            string image = "test.jpg")
        {
            return new Product(name, description, price, stock, image);
        }

        public static Product CreateValidProductWithId(
            int id,
            string name = "Test Product",
            string description = "Test Description",
            decimal price = 10.50m,
            int stock = 100,
            string image = "test.jpg")
        {
            return new Product(id, name, description, price, stock, image);
        }
    }
}