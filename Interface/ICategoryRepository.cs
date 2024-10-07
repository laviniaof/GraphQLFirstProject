using GraphQLProject.Models;

namespace GraphQLProject.Interface
{
    public interface ICategoryRepository
    {

        List<Category> GetCategories();

        Category AddCategoryy(Category category);

        Category UpdateCategory(int id, Category category);

        void DeleteCategory(int id);
    }
}
