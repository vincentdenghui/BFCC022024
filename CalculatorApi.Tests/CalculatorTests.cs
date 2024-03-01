namespace CalculatorApi.Tests;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

public class CalculatorApiTests
{
    [Fact]
    public async Task InvalidOperator(){ //op=adddd , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/adddd?operandA=str&operandB=str");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task AddOneOne(){ //1+1=2, StatusCode = Ok
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/add?operandA=1&operandB=1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("\"2\"", payload);
    }
    
    [Fact]
    public async Task AddOnePointOneTwoPointOne(){ //1.1+2.1=3.2, StatusCode = Ok
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/add?operandA=1.1&operandB=2.1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("\"3.2\"", payload);    
    }

    [Fact]
    public async Task AddOneMissing(){ //1+__ = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/add?operandA=1&operandB=");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task AddMissingOne(){ //__+1 = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/add?operandA=&operandB=1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task AddMissingMissing(){ //__+__ = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/add?operandA=&operandB=");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task AddOneString(){ //1+str = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/add?operandA=1&operandB=str");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task AddStringOne(){ //str+1 = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/add?operandA=str&operandB=1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task AddStringString(){ //str+str = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/add?operandA=str&operandB=str");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task SubtractOneOne(){ //1-1=0, StatusCode = Ok
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/subtract?operandA=1&operandB=1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("\"0\"", payload);
    }
    
    [Fact]
    public async Task SubtractOnePointOneTwoPointOne(){ //1.1-2.1=-1, StatusCode = Ok
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/subtract?operandA=1.1&operandB=2.1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("\"-1\"", payload);    
    }

    [Fact]
    public async Task SubtractOneMissing(){ //1-__ = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/subtract?operandA=1&operandB=");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task SubtractMissingOne(){ //__-1 = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/subtract?operandA=&operandB=1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task SubtractMissingMissing(){ //__-__ = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/subtract?operandA=&operandB=");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task SubtractOneString(){ //1-str = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/subtract?operandA=1&operandB=str");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task SubtractStringOne(){ //str-1 = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/subtract?operandA=str&operandB=1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task SubtractStringString(){ //str-str = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/subtract?operandA=str&operandB=str");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task MultiplyOneOne(){ //1*1=1, StatusCode = Ok
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/multiply?operandA=1&operandB=1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("\"1\"", payload);
    }
    
    [Fact]
    public async Task MultiplyOnePointOneTwoPointOne(){ //1.1*2.1=2.31, StatusCode = Ok
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/multiply?operandA=1.1&operandB=2.1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("\"2.3100000000000005\"", payload);    
    }

    [Fact]
    public async Task MultiplyOneMissing(){ //1*__ = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/multiply?operandA=1&operandB=");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task MultiplyMissingOne(){ //__*1 = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/multiply?operandA=&operandB=1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task MultiplyMissingMissing(){ //__*__ = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/multiply?operandA=&operandB=");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task MultiplyOneString(){ //1*str = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/multiply?operandA=1&operandB=str");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task MultiplyStringOne(){ //str*1 = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/multiply?operandA=str&operandB=1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task MultiplyStringString(){ //str*str = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/multiply?operandA=str&operandB=str");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task DivideOneOne(){ //1/1=1, StatusCode = Ok
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/divide?operandA=1&operandB=1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("\"1\"", payload);
    }
    
    [Fact]
    public async Task DivideOneTwo(){ //1/2=0.5, StatusCode = Ok
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/divide?operandA=1&operandB=2");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("\"0.5\"", payload);    
    }

    [Fact]
    public async Task DivideOnePointOneByZero(){ //1.1/0=+inf, StatusCode = Ok
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/divide?operandA=1.1&operandB=0");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("\"∞\"", payload);    
    }
    
    [Fact]
    public async Task DivideOneMissing(){ //1/__ = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/divide?operandA=1&operandB=");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task DivideMissingOne(){ //__/1 = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/divide?operandA=&operandB=1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task DivideMissingMissing(){ //__/__ = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/divide?operandA=&operandB=");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task DivideOneString(){ //1/str = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/divide?operandA=1&operandB=str");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task DivideStringOne(){ //str/1 = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/divide?operandA=str&operandB=1");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task DivideStringString(){ //str/str = , StatusCode = BadRequest
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/calculator/divide?operandA=str&operandB=str");
        var payload = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}