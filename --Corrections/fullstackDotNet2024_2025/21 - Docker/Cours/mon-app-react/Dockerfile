# FROM node:alpine

# WORKDIR /app

# COPY package*.json ./

# RUN npm install 

# COPY . .

# EXPOSE 3000 2000

# CMD ["npm", "start"]

FROM node:alpine AS build

WORKDIR /app

ADD package*.json ./

RUN npm install

COPY . . 

RUN npm run build

FROM nginx:stable-alpine AS deploy

COPY --from=build /app/build /usr/share/nginx/html

EXPOSE 80

CMD [ "nginx", "-g", "daemon off;" ]