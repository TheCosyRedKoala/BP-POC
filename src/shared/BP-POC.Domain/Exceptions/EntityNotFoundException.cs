namespace BP_POC.Domain.Exceptions;

public class EntityNotFoundException
{
    /// <param name="entityName">Name / type of the <see cref="Entity"/>.</param>
    /// <param name="id">The identifier of the duplicate key.</param>
    public EntityNotFoundException(string entityName, object id) : base($"'{entityName}' with 'Id':'{id}' was not found.")
    {
    }
}
