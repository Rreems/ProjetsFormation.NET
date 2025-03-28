

FROM node:alpine AS build

WORKDIR /mon_app

ADD package*.json ./

RUN npm install

COPY . . 

RUN npm run build

FROM nginx:stable-alpine AS deploy


EXPOSE 80

CMD [ "nginx", "-g", "daemon off;" ]