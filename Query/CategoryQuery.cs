using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interface;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class CategoryQuery : ObjectGraphType
    {
        public CategoryQuery (ICategoryRepository categoryRepository)
        {
            Field<ListGraphType<CategoryType>>("Categories").Resolve(context =>
            {
                return categoryRepository.GetCategories();
            });
        }
    }
}
