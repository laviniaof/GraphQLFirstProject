using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Type
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType() 
        {
            Field(c => c.Id);
            Field(c => c.Name);
            Field(c => c.ImageUrl);
        }

    }
}
