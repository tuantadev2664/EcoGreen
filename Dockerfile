# 👉 1. Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Sao chép file solution và project
COPY EcoGreen/EcoGreen.csproj ./EcoGreen/
COPY Common/Common.csproj ./Common/
COPY Application/Application.csproj ./Application/
COPY InfrasStructure/InfrasStructure.csproj ./InfrasStructure/
COPY EcoGreen.sln ./

# Khôi phục package
RUN dotnet restore EcoGreen.sln

# Sao chép toàn bộ mã nguồn
COPY . .

# Build và publish
RUN dotnet publish EcoGreen/EcoGreen.csproj -c Release -o /app/out

# 👉 2. Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy file publish
COPY --from=build /app/out ./

# Copy vision.json vào đúng vị trí nếu dùng trực tiếp
# COPY EcoGreen/Extensions/vision.json /app/Extensions/vision.json

# Mở cổng
EXPOSE 8080

# Điểm khởi động
ENTRYPOINT ["dotnet", "EcoGreen.dll"]
