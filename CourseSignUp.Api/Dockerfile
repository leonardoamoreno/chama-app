FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim

WORKDIR /app

COPY ./dist .

ENTRYPOINT ["dotnet", "CourseSignUp.Api.dll"]