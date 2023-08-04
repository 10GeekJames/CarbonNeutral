# syntax=docker/dockerfile:1
FROM nginx:alpine as base

WORKDIR /usr/share/nginx/html
COPY ./build/local-reverse-proxy/Domain.crt .
COPY ./build/local-reverse-proxy/Domain.key .

WORKDIR /
COPY ./build/local-reverse-proxy/ngix.conf /etc/nginx/nginx.conf
COPY ./build/local-reverse-proxy/entrypoint.sh .

EXPOSE 443/tcp
EXPOSE 80/tcp
CMD /bin/sh ./entrypoint.sh

FROM base