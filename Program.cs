using GraphQLProject.Interface;
using GraphQLProject.Services;
using GraphQLProject.Type;
using GraphQLProject.Query;
using GraphQLProject.Schema;
using GraphQLProject.Mutation;
using GraphQL.Types;
using GraphQL;
using GraphiQl;
using GraphQLProject.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<IReservationRepository, ReservationRepository>();

builder.Services.AddTransient<MenuType>();
builder.Services.AddTransient<CategoryType>();
builder.Services.AddTransient<ReservationType>();

builder.Services.AddTransient<MenuQuery>();
builder.Services.AddTransient<CategoryQuery>();
builder.Services.AddTransient<ReservationQuery>();
builder.Services.AddTransient<RootQuery>();

//builder.Services.AddTransient<MenuMutation>();
//builder.Services.AddTransient<MenuInputType>();

builder.Services.AddTransient<ISchema,RootSchema>();

builder.Services.AddGraphQL(b => b.AddAutoSchema<ISchema>().AddSystemTextJson());

builder.Services.AddDbContext<GraphQLDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLDbContextConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGraphiQl("/graphql");

app.UseGraphQL<ISchema>(); 

app.MapControllers();

app.Run();
