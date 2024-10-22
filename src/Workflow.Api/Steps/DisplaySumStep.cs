using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Api.Steps;

public class DisplaySumStep(ILogger<DisplaySumStep> logger) : StepBody
{
    public int Sum { get; init; }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        logger.LogInformation("Running display sum step. Sum of two numbers: {Sum}", Sum);

        return ExecutionResult.Next();
    }
}