docker build -t chronicle-api-image -f Infrastructure/api-dev.dockerfile .

docker run --rm -d -e ASPNETCORE_ENVIRONMENT=Development -p 8080:80 --name chronicle-api chronicle-api-image