FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /CleanArchMvc
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:8000;http://+:80;

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /CleanArchMvc
COPY --from=build-env /CleanArchMvc/out .
ENTRYPOINT ["dotnet", "CleanArchMvc.WebUI.dll"]