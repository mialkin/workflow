# Workflow Core

Showcase of [↑ Workflow Core](https://github.com/danielgerlag/workflow-core) library.

## Prerequisites

- .NET 8 SDK
- Docker

## Running application

Run infrastructure:

```bash
docker compose --file src/Workflow.Api/infrastructure.yaml up --detach
```

Run application:

```bash
dotnet watch --no-hot-reload --project=src/Workflow.Api
```

Shutdown infrastructure:

```bash
docker compose --file src/Workflow.Api/infrastructure.yaml down
```

## Other workflow engines

- [↑ Elsa](https://github.com/elsa-workflows/elsa-core)
- [↑ Temporal](https://github.com/temporalio/sdk-dotnet)
- [↑ Camunda](https://camunda.com/blog/2022/11/camunda-platform-8-dotnet-developers/)

[↑ Elsa vs Temportal vs Camunda vs Workflow Core](https://stackoverflow.com/questions/78479207/elsa-vs-temportal-vs-camunda-vs-workflow-core).