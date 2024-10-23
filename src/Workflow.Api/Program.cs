using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
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
// services.AddWorkflow(
//     x => x.UseMongoDB(mongoUrl: "mongodb://workflow:workflow@localhost:5230", databaseName: "workflow"));

services.AddWorkflow(
    x => x.UsePostgreSQL(
        connectionString: "User ID=workflow;Password=workflow;Host=localhost;Port=5240;Database=workflow",
        canCreateDB: true,
        canMigrateDB: true));

services.AddTransient<CalculationStep>();
services.AddTransient<DisplaySumStep>();
services.AddTransient<ManualStep>();

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
    });

application.MapGet(
    pattern: "/publish-event",
    handler: void (IWorkflowHost host) => host.PublishEvent(
        eventName: EventNames.MyEvent,
        eventKey: EventKeys.MyKey,
        eventData: null));

var host = application.Services.GetService<IWorkflowHost>();
host!.RegisterWorkflow<HelloWorldWorkflow, WorkflowContext>();

// var objectSerializer = new ObjectSerializer(ObjectSerializer.AllAllowedTypes);
// BsonSerializer.RegisterSerializer(objectSerializer);

host.Start();

application.Run();