namespace RBTB_ServiceAccount.Application.Domains.Responses;

public class BaseResponse<T>
{
    public bool Success { get; set; } = true;

    public string ErrorMessage { get; set; } = string.Empty;
    
    public T Data { get; set; }
}