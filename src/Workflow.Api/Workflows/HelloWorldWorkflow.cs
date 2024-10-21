using Workflow.Api.Constants;
using Workflow.Api.Steps;
using WorkflowCore.Interface;

namespace Workflow.Api.Workflows;

public class HelloWorldWorkflow : IWorkflow
{
    public string Id => WorkflowIds.HelloWorld;
    public int Version => 1;

    public void Build(IWorkflowBuilder<object> builder)
    {
        builder
            .StartWith<HelloWorldStep>()
            .Then<GoodbyeWorldStep>();
    }
}