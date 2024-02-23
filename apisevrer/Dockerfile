FROM node:14-alpine

WORKDIR /usr/src/app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build


ENV PORT=3005

EXPOSE $PORT


CMD ["node", "build/index.js"]

