dotnet sonarscanner begin /o:"sotheareth" /k:"sotheareth_MongoDBWebAPI" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="%SONAR_TOKEN%"
dotnet build
dotnet sonarscanner end /d:sonar.login="%SONAR_TOKEN%"