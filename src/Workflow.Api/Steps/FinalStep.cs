using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Api.Steps;

public class FinalStep(ILogger<CalculationStep> logger) : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        logger.LogInformation("Running final step");

        return ExecutionResult.Next();
    }
}