# Emma

> Employee Management More Awesome

## UI

The UI is implemented in Angular, using Angular Material for styling. To start the UI in development mode, run

```bash
cd Emma.ui && ng serve -o
```

## API

The API is implemented with ASP.NET, using the latest .NET 6. To start the API, make sure you have the database up and running, then run

```bash
cd Emma.Api/Emma.Api && dotnet run
```

## Database

The chosen database is PostrgeSQL. A simple Docker Compose configuration is provided to make it easy to start up a Postgres instance. Simply run

```bash
docker-compose up -d
```
