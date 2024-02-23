FROM node:14-alpine

WORKDIR /usr/src/app

COPY package*.json ./

RUN npm install

COPY . .

ENV PORT=3000
ENV API_PORT=3005

EXPOSE $PORT

CMD ["npm", "start"]
