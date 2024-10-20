using Workflow.Api.Workflows;
using WorkflowCore.Interface;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddWorkflow(x => x.UseMongoDB("mongodb://workflow:workflow@localhost:5230", "workflow"));

var application = builder.Build();

application.UseSwagger();
application.UseSwaggerUI();

application.MapGet(
        pattern: "/",
        handler: () => "ping")
    .WithOpenApi();

var host = application.Services.GetService<IWorkflowHost>();
host!.RegisterWorkflow<HelloWorldWorkflow>();
host.Start();

// _ = host.StartWorkflow(workflowId: "HelloWorld", data: 1, reference: null);

application.Run();