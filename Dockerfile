# .NET Core 3.1 をベースイメージとする
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
# 作業ディレクリの指定
WORKDIR /app

# プロジェクトをコピーして別のレイヤーで復元します。
COPY *.csproj ./
RUN dotnet restore

# 全てコピーしてビルドします。
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "shopping-api.dll"]