using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Api.Steps;

public class FinalStep(ILogger<CalculationStep> logger) : StepBody
{
    public int Sum { get; init; }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        logger.LogInformation("Running final step. Sum of two numbers: {Sum}", Sum);

        return ExecutionResult.Next();
    }
}