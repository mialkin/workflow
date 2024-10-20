using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Api.Steps;

public class GoodbyeWorldStep(ILogger<HelloWorldStep> logger) : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        logger.LogInformation("Goodbye world");

        return ExecutionResult.Next();
    }
}