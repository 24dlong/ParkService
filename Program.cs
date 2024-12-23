using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text.Json;
using ParkService;
using ParkService.Data;
using ParkService.GraphQL;
using ParkService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => {
    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
}).AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower; // Use snake_case
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower; // Optional for dictionary keys
});

builder.Services.AddScoped<IParkRepository, ParkRepository>();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddApolloFederation()
    .AddType<Park>()
    .AddType<Trail>();
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.MapGraphQL();

app.Run();
