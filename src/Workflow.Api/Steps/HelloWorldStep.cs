using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Api.Steps;

public class HelloWorldStep(ILogger<HelloWorldStep> logger) : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        logger.LogInformation("Hello world");

        return ExecutionResult.Next();
    }
}