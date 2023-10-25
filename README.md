
# User Notebook

The "User Notebook" application is designed to store and manage user data. It consists of a main view with a user table and a secondary view for adding/editing user information.

# Requirements

|   Package name       | Version      |
|--------------|-----------|
| Dotnet | **v7**      |
| Node      |  **v18.17.1** |

# How to run?

### Clone repository
```
    git clone https://github.com/kynaios/UserNotebook.git
```

### Go to project
```
    cd UserNotebook
```

### Run Postgres
```
    docker compose up -d
```

## Server
```
    dotnet run
```

## Client

### Go to project
```
    cd client
```

### Install dependencies
```
    pnpm install
```

### Run
```
    pnpm dev
```

Go to `http://localhost:5173/`

# Docker

On the [docker](https://github.com/kynaios/UserNotebook/tree/docker) branch there is a dockerized version of the application. The current state is that forms cannot be sent (CORS problem).

### Clone repository
```
    git clone https://github.com/kynaios/UserNotebook.git -b docker
```

### Run Postgres
```
    docker compose up -d
```

### Run migrations
```
    dotnet run
```

### Change hostname to postgres and uncomment docker-compose content
Change `"USER_NOTEBOOK_HOST": "localhost"` to `"USER_NOTEBOOK_HOST": "postgres"` inside `appsettings.json` and and uncomment docker-compose content

### Run application
```
    docker compose up -d
```

Application is running on `localhost:5000`