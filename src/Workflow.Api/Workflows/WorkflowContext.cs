namespace Workflow.Api.Workflows;

public record WorkflowContext
{
    public int Number1 { get; init; }
    public int Number2 { get; init; }
    public int Sum { get; init; }
}