namespace Demo.Domain.Core;

public class UpsertResult<T>
{
    public T Response { get; }
    public bool IsEdit { get; } = false;

    public UpsertResult(T response, bool isEdit)
    {
        this.IsEdit = isEdit;
        this.Response = response;
    }
}