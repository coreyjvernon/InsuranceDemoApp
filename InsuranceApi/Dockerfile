# Use the official ASP.NET runtime as base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["InsuranceApi.csproj", "./"]
RUN dotnet restore "InsuranceApi.csproj"
COPY . .
RUN dotnet build "InsuranceApi.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "InsuranceApi.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InsuranceApi.dll"]
