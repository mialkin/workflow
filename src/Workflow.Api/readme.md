# Workflow API

Showcase of [↑ Workflow Core](https://github.com/danielgerlag/workflow-core) library.

## Prerequisites

- [↑ .NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [↑ Docker](https://www.docker.com/products/docker-desktop/)

## Running application

Run infrastructure:

```bash
docker compose --file infrastructure.yaml up --detach
```

Run application:

```bash
dotnet watch --no-hot-reload
```

Shutdown infrastructure:

```bash
docker compose --file infrastructure.yaml down
```

## Other workflow engines

- [↑ Elsa](https://github.com/elsa-workflows/elsa-core)
- [↑ Temporal](https://github.com/temporalio/sdk-dotnet)
- [↑ Camunda](https://camunda.com/blog/2022/11/camunda-platform-8-dotnet-developers/)

[↑ Elsa vs Temportal vs Camunda vs Workflow Core](https://stackoverflow.com/questions/78479207/elsa-vs-temportal-vs-camunda-vs-workflow-core).