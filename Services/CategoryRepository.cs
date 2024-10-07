using GraphQLProject.Data;
using GraphQLProject.Interface;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private GraphQLDbContext dbContext;

        public CategoryRepository(GraphQLDbContext dbContext) 
        {
            this.dbContext = dbContext;
        } 

        public Category AddCategoryy(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            var categoryResult = dbContext.Categories.Find(id);
            dbContext.Categories.Remove(categoryResult);
            
        }

        public List<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }

        public Category UpdateCategory(int id, Category category)
        {
            var categoryResult = dbContext.Categories.Find(id);
            categoryResult.Name = category.Name;
            categoryResult.ImageUrl = category.ImageUrl;
            dbContext.SaveChanges();
            return category;
        }
    }
}
