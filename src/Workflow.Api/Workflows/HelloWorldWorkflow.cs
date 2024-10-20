using Workflow.Api.Steps;
using WorkflowCore.Interface;

namespace Workflow.Api.Workflows;

public class HelloWorldWorkflow : IWorkflow
{
    public string Id => "Hello World";
    public int Version => 1;

    public void Build(IWorkflowBuilder<object> builder)
    {
        builder
            .StartWith<HelloWorldStep>()
            .Then<GoodbyeWorldStep>();
    }
}