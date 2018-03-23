# Use the standard Microsoft .NET Core container
FROM microsoft/dotnet
WORKDIR /app  
COPY . .

RUN dotnet restore \
    && dotnet build
 
CMD dotnet run --server.urls http://0.0.0.0:$PORT
