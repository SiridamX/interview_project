namespace BackEnd.API.Models.Responses;

public class ApiResponse<T>
{
    public int Status { get; set; }
    public T Data { get; set; }

    public ApiResponse(int status, T data)
    {
        Status = status;
        Data = data;
    }
}
