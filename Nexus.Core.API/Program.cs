using YourProjectName.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddSingleton<ITimeService, TimeService>();
builder.Services.AddScoped<IRequestCounterService, RequestCounterService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();