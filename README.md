# Clone Web

A dependency-free Node.js development site bootstrapped for the Alloy environment.

## Development

Start the containerized development server:

```sh
docker compose -f docker-compose.alloy.yaml up -d
```

The site listens on `http://localhost:3000`. Source files are bind-mounted into the container, and changes restart the server automatically.
