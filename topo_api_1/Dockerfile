FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet build
EXPOSE 80/tcp
#EXPOSE 22 #SQL SERVER?

ARG env=local
ENV ASPNETCORE_URLS http://*:5000
ENV SERVER $env

RUN chmod 755 ./entrypoint.sh
#CMD /bin/bash ./entrypoint.sh
CMD ["./entrypoint.sh"]
#RUN dotnet publish -c Release -o out


# Build runtime image
#FROM microsoft/aspnetcore-build:2.0
#WORKDIR /app
#COPY --from=build-env /app/out .
#COPY --from=build-env /app/entrypoint.sh .
#RUN chmod 755 ./entrypoint.sh
#CMD /bin/bash ./entrypoint.sh
#ENTRYPOINT ["./entrypoint.sh"]
#ENTRYPOINT ["dotnet", "topo_api_1.dll"]