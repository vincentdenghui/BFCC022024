var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/calculator/{op}",  (string op, double operandA, double operandB) => {
      double result = double.NaN;
      try{
            result = op switch{
                "add" => operandA + operandB,
                "subtract" => operandA - operandB,
                "multiply" => operandA * operandB,
                "divide" => operandA / operandB,
                _ => throw new ArgumentException()
            };
        }catch (ArgumentException){
                return Results.BadRequest($"bad operator:{op}");
        }
        return Results.Ok($"{result}");
});


app.Run();

// for testing
public partial class Program { }