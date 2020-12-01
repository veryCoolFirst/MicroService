#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
# 进入docker中的/usr/local/src目录
RUN cd /usr/local/src
 
# 创建DockerWebAPI目录
RUN mkdir ProductService
 
# 设置工作路径
WORKDIR /usr/local/src/ProductService
 
# 将当前文件夹下的所有文件全部复制到工作目录
COPY *.* ./
 
# 向外界暴露5000端口
EXPOSE 5278
 
# 执行dotnet DockerWebAPI.dll命令
CMD ["dotnet", "MicroService.Api.dll"]