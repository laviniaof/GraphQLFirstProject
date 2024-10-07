using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interface;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class MenuQuery : ObjectGraphType
    {
        public MenuQuery(IMenuRepository menuRepository)
        {
            Field<ListGraphType<ReservationType>>("Menus").Resolve(context =>
            {
                return menuRepository.GetAllMenu();
            });

            Field<ReservationType>("Menu").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId"})).Resolve(context =>
            {
                return menuRepository.GetMenuById(context.GetArgument<int>("menuId"));
            });
        }
    }
}
