using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Api.Steps;

public class CalculationStep(ILogger<CalculationStep> logger) : StepBody
{
    public int Input1 { get; set; }
    public int Input2 { get; set; }
    public int Output { get; set; }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        logger.LogInformation("Hello world");

        return ExecutionResult.Next();
    }
}