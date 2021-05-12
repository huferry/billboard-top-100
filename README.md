
# Docker Compose
```bash
# Please inspect the file docker-compose.yml

# Start containers
docker-compuse up -d

# Stop containers
docker-compose down
```

# Docker Swarm

```bash
# Build the images
docker build -t billboard_api:latest ./billboard-server/ 
docker build -t billboard_frontend:latest ./billboard-client/

# Create overlay network
docker network create --driver overlay billboard

# Create Posgres Service
docker service create \
    --name billpsql \
    --network billboard \
    -e POSTGRES_USER=user \
    -e POSTGRES_DB=billboard \
    -e POSTGRES_PASSWORD=password \
    postgres

# Create API server
docker service create \
    --name billapi \
    --network billboard \
    -p 81:80 \
    -e DB_CONNECTION_STRING="host=billpsql;port=5432;database=billboard;username=user;password=password" \
    billboard_api

# Scaling API to 3 replicas
docker service scale billapi=3

# Create frontend server
docker service create \
    --name billweb \
    --network billboard \
    -p 80:3000 \
    -e REACT_APP_API="http://localhost:81/api" \
    billboard_frontend

# Scaling Web server to 2 replicas
docker service scale billweb=2

```