namespace RBTB_ServiceAccount.Application.Domains.Responses;

public class BaseResponse<T>
{
    public bool Success { get; set; } = true;

    public T Data { get; set; }
}