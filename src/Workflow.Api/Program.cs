using Scalar.AspNetCore;
using Workflow.Api.Constants;
using Workflow.Api.Steps;
using Workflow.Api.Workflows;
using WorkflowCore.Interface;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddWorkflow(x => x.UseMongoDB("mongodb://workflow:workflow@localhost:5230", "workflow"));
services.AddTransient<HelloWorldStep>();
services.AddTransient<GoodbyeWorldStep>();

var application = builder.Build();

application.UseSwagger(options => { options.RouteTemplate = "openapi/{documentName}.json"; });

application.MapScalarApiReference(x => { x.Title = "Workflow Core API"; });

application.MapGet("/", () => Results.Redirect("/scalar/v1")).ExcludeFromDescription();

application.MapGet(
    "/start", (IWorkflowHost host) =>
    {
        _ = host.StartWorkflow(workflowId: WorkflowIds.HelloWorld, data: null, reference: null);


        // host.PublishEvent(
        //     eventName: "Whatever",
        //     eventKey: "key",
        //     eventData: new { Message = "Hello World!" });
    });

var host = application.Services.GetService<IWorkflowHost>();
host!.RegisterWorkflow<HelloWorldWorkflow>();
host.Start();

application.Run();