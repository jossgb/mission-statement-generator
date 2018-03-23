dotnet publish -c Release
heroku container:login
docker build -t mission-statement-generator  ./bin/Release/netcoreapp1.1/publish
docker tag mission-statement-generator registry.heroku.com/mission-statement-generator/web
docker push registry.heroku.com/mission-statement-generator/web
