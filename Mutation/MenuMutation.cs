using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interface;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenuRepository menuRepository) 
        {
            Field<ReservationType>("CreateMenu").Arguments(new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" })).Resolve(context =>
            {
                return menuRepository.AddMenu(context.GetArgument<Menu>("menu"));
            });

            Field<ReservationType>("UpdateMenu").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" },
                new QueryArgument<MenuInputType> { Name = "menu" })).Resolve(context =>
            {
                var menu = context.GetArgument<int>("menuId");
                var menuId = context.GetArgument<Menu>("menu");
                return menuRepository.UpdateMenu(menu, menuId);
            });

            Field<StringGraphType>("DeleteMenu").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" })).Resolve(context =>
            {
                var menuId = context.GetArgument<int>("menu");
                menuRepository.DeleteMenu(menuId);
                return "The menu against this Id" + menuId + "has been deleted";
            });
        }
    }
}
