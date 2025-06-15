using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Mock;
using Repository.Interfaces;
using Service.Interfaces;
using Service;
using Common.Dto;
using System.Text;
using Repository.Entities;
using Repository.Reposetories;
using Repository.Repositories;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// ✅ הרשמה לשירותים שלך
builder.Services.AddScoped<IService<CustomerDto>, CustomerService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>(); // או השם המדויק שלך
builder.Services.AddAutoMapper(typeof(MyMapper)); // או typeof(Startup) / typeof(AutoMapperProfile)
builder.Services.AddScoped<IService<DietDto>, DietTypeService>();//לשים לב אם זה נכון
builder.Services.AddScoped<IRepository<DietType>, DietTypeRepository>();//לשים לב אם זה נכון
builder.Services.AddScoped<IService<WeeklyTrackingDto>, WeeklyTrackingService>();//לשים לב אם זה נכון
builder.Services.AddScoped<IRepository<WeeklyTracking>, WeeklyTrackingRepository>();//לשים לב אם זה נכון
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFoodPreferenceRepository, FoodPreferenceRepository>();
builder.Services.AddScoped<IContext, Database>();

builder.Services.AddScoped<IService<ProductDto>, ProductService>();//לשים לב אם זה נכון
builder.Services.AddScoped < IRepository <Product>, ProductRepository>();//לשים לב אם זה נכון


// לדוגמה, אם יש גם:
// builder.Services.AddScoped<IService<CategoryDto>, CategoryService>();
// builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
// builder.Services.AddAutoMapper(typeof(MyMapper));
// builder.Services.AddScoped<IContext, Database>(); // אם זה לא קיים כבר

builder.Services.AddDbContext<IContext, Database>();

// ✅ Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// ✅ CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();