namespace PaymentMicroservice.API.Middleware;

public class ErrorView
{
    public string Code { get; }
    public string Message { get; }

    private ErrorView() { }

    public ErrorView(string code, string message)
    {
        Code = code;
        Message = message;
    }
}