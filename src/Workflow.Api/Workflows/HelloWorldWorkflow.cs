using Workflow.Api.Constants;
using Workflow.Api.Steps;
using WorkflowCore.Interface;

namespace Workflow.Api.Workflows;

public class HelloWorldWorkflow : IWorkflow<WorkflowContext>
{
    public string Id => WorkflowIds.HelloWorld;
    public int Version => 1;

    public void Build(IWorkflowBuilder<WorkflowContext> builder)
    {
        builder
            .StartWith<CalculationStep>()
            .Input(x => x.Input1, y => y.Number1)
            .Input(x => x.Input2, y => y.Number2)
            .Output(x => x.Answer, y => y.Output)
            .Then<GoodbyeWorldStep>();
    }
}