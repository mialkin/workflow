using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Api.Steps;

public class GoodbyeWorldStep(ILogger<CalculationStep> logger) : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        logger.LogInformation("Calculate things");

        return ExecutionResult.Next();
    }
}