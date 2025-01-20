using System.Collections.Immutable;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Extensions;

public class OperationResult<TEntity>
{
    public OperationResult()
    {
        Messages = [];
    }

    public OperationResult(params ResultMessage[] messages)
    {
        Messages = [.. messages];
    }

    public TEntity? Value { get; init; }
    public bool HasErrors() => Messages.Count > 0;
    public bool Sucesso => !HasErrors();
    public IReadOnlyCollection<ResultMessage> Messages { get; init; }
    public IEnumerable<ResultMessage> SearchForErrors() 
        => Messages.Where(message => message.ResultType == ResultTypes.Error);
}