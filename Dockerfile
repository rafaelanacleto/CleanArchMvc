FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /CleanArchMvc

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
ENTRYPOINT ["dotnet", "CleanArchMvc.WebUI/obj/Release/net8.0/CleanArchMvc.WebUI.dll"]