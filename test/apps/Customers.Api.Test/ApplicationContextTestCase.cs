namespace Dew.Customers.Api.Test;

public class ApplicationContextTestCase : IClassFixture<ApplicationTestCase>
{
    private readonly ApplicationTestCase _applicationTestCase;

    public HttpClient Client { get; }

    public ApplicationContextTestCase(ApplicationTestCase applicationTestCase)
    {
        _applicationTestCase = applicationTestCase;
        
        Client = _applicationTestCase.CreateClient();
    }
}
