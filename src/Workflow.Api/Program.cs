using Scalar.AspNetCore;
using Serilog;
using Workflow.Api.Constants;
using Workflow.Api.Steps;
using Workflow.Api.Workflows;
using WorkflowCore.Interface;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

builder.Host.UseSerilog(
    (context, configuration) =>
    {
        configuration.ReadFrom.Configuration(context.Configuration);
        configuration.WriteTo.Console();
    });

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddWorkflow(x => x.UseMongoDB("mongodb://workflow:workflow@localhost:5230", "workflow"));
services.AddTransient<HelloWorldStep>();
services.AddTransient<GoodbyeWorldStep>();

var application = builder.Build();

application.UseSerilogRequestLogging();
application.UseSwagger(options => { options.RouteTemplate = "openapi/{documentName}.json"; });

application.MapScalarApiReference(x => { x.Title = "Workflow Core API"; });

application.MapGet("/", () => Results.Redirect("/scalar/v1")).ExcludeFromDescription();

application.MapGet(
    "/start-workflow", async (IWorkflowHost host, ILogger<Program> logger) =>
    {
        var id = await host.StartWorkflow(
            workflowId: WorkflowIds.HelloWorld,
            data: new WorkflowContext { Number1 = 5, Number2 = 10 },
            reference: null);

        logger.LogInformation("Workflow started. Workflow ID: {WorkflowId}", id);

        // host.PublishEvent(
        //     eventName: "Whatever",
        //     eventKey: "key",
        //     eventData: new { Message = "Hello World!" });
    });

var host = application.Services.GetService<IWorkflowHost>();
host!.RegisterWorkflow<HelloWorldWorkflow, WorkflowContext>();
host.Start();

application.Run();