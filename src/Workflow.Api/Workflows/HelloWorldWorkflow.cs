using Workflow.Api.Constants;
using Workflow.Api.Steps;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow.Api.Workflows;

public class HelloWorldWorkflow(ILogger<HelloWorldWorkflow> logger) : IWorkflow<WorkflowContext>
{
    public string Id => WorkflowIds.HelloWorld;
    public int Version => 1;

    public void Build(IWorkflowBuilder<WorkflowContext> builder)
    {
        builder
            .StartWith<CalculationStep>()
            .Input(x => x.Input1, y => y.Number1)
            .Input(x => x.Input2, y => y.Number2)
            .Output(x => x.Sum, y => y.Output)
            .Then<DisplaySumStep>()
            .Input(x => x.Sum, y => y.Sum)
            .Then<ManualStep>()
            .WaitFor(eventName: EventNames.MyEvent, eventKey: x => EventKeys.MyKey)
            .Then(
                _ =>
                {
                    logger.LogInformation("Workflow complete");
                    return ExecutionResult.Next();
                }
            );
    }
}