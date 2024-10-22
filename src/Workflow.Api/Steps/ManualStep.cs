using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Api.Steps;

public class ManualStep(ILogger<ManualStep> logger) : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        logger.LogInformation("Running manual step");
        
        return ExecutionResult.Next();
    }
}