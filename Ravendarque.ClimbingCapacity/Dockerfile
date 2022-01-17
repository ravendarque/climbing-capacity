#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ravendarque.ClimbingCapacity.Web.csproj", "Ravendarque.ClimbingCapacity.Web/"]
RUN dotnet restore "Ravendarque.ClimbingCapacity.Web/Ravendarque.ClimbingCapacity.Web.csproj"
COPY . Ravendarque.ClimbingCapacity.Web/
WORKDIR "/src/Ravendarque.ClimbingCapacity.Web"
RUN dotnet build "Ravendarque.ClimbingCapacity.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ravendarque.ClimbingCapacity.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ravendarque.ClimbingCapacity.Web.dll"]