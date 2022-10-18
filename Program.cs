using System.Text.Json.Serialization;
using TodoAPi.Externsions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        }); ;


builder.Services.AddRepositories();
builder.Services.AddSwagger();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();



app.MapControllers();

app.Run();
