FROM node:18.18.2-alpine3.18 AS base
WORKDIR /app
COPY . /app
EXPOSE 3000
RUN npm install
RUN npm run build

FROM base AS final
WORKDIR /app
COPY --from=base /app/build .
ENTRYPOINT ["node", "build"]
