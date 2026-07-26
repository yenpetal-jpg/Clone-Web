# Tin Việt

A static Vietnamese news experience, built with ASP.NET Core 8 MVC. It includes reusable layouts, sample editorial data, category and article pages, search results, and a sign-in placeholder.

## Development

Start the containerized development server:

```sh
docker compose -f docker-compose.alloy.yaml up -d
```

The site listens on `http://localhost:3000`. Source files are bind-mounted into the container, and `dotnet watch` restarts the application automatically.
