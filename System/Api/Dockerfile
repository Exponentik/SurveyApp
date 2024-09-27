#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["System/Api/Api.csproj", "System/Api/"]
COPY ["Data/SurveyApp.Context/SurveyApp.Context.csproj", "Data/SurveyApp.Context/"]
COPY ["Data/SurveyApp.Context.Entities/SurveyApp.Context.Entities.csproj", "Data/SurveyApp.Context.Entities/"]
COPY ["Services/SurveyApp.Services.Answers/SurveyApp.Services.Answers.csproj", "Services/SurveyApp.Services.Answers/"]
COPY ["Services/SurveyApp.Services.Interviews/SurveyApp.Services.Interviews.csproj", "Services/SurveyApp.Services.Interviews/"]
COPY ["Services/SurveyApp.Services.Questions/SurveyApp.Services.Questions.csproj", "Services/SurveyApp.Services.Questions/"]
COPY ["Services/SurveyApp.Services.Results/SurveyApp.Services.Results.csproj", "Services/SurveyApp.Services.Results/"]
COPY ["Services/SurveyApp.Services.Surveys/SurveyApp.Services.Surveys.csproj", "Services/SurveyApp.Services.Surveys/"]
RUN dotnet restore "./System/Api/Api.csproj"
COPY . .
WORKDIR "/src/System/Api"
RUN dotnet build "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]