#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CourseSignUp.Api/CourseSignUp.Api.csproj", "CourseSignUp.Api/"]
COPY ["CourseSignUp.Infra.CrossCuting.Bus/CourseSignUp.Infra.CrossCuting.Bus.csproj", "CourseSignUp.Infra.CrossCuting.Bus/"]
COPY ["CourseSignUp.Domain.Core/CourseSignUp.Domain.Core.csproj", "CourseSignUp.Domain.Core/"]
COPY ["CourseSignUp.Infra.CrossCutting.IoC/CourseSignUp.Infra.CrossCutting.IoC.csproj", "CourseSignUp.Infra.CrossCutting.IoC/"]
COPY ["CourseSignUp.Domain/CourseSignUp.Domain.csproj", "CourseSignUp.Domain/"]
COPY ["CourseSignUp.Application/CourseSignUp.Application.csproj", "CourseSignUp.Application/"]
COPY ["CourseSignUp.Infra.Data/CourseSignUp.Infra.Data.csproj", "CourseSignUp.Infra.Data/"]
RUN dotnet restore "CourseSignUp.Api/CourseSignUp.Api.csproj"
COPY . .
WORKDIR "/src/CourseSignUp.Api"
RUN dotnet build "CourseSignUp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseSignUp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseSignUp.Api.dll"]