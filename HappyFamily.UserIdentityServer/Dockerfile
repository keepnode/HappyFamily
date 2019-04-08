FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["HappyFamily.UserIdentityServer/HappyFamily.UserIdentityServer.csproj", "HappyFamily.UserIdentityServer/"]
RUN dotnet restore "HappyFamily.UserIdentityServer/HappyFamily.UserIdentityServer.csproj"
COPY . .
WORKDIR "/src/HappyFamily.UserIdentityServer"
RUN dotnet build "HappyFamily.UserIdentityServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HappyFamily.UserIdentityServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HappyFamily.UserIdentityServer.dll"]