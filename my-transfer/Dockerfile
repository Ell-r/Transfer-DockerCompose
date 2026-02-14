# Виберіть базовий образ
FROM node:18 AS build

# Встановіть робочий каталог
WORKDIR /app

# Скопіюйте package.json і package-lock.json
COPY package*.json ./

# Встановіть залежності
RUN npm install

# Скопіюйте весь код
COPY . .

# Побудуйте проект
RUN npm run build

# Виберіть образ для продакшн
FROM nginx:alpine
# Скопіюйте побудовані файли в каталог для сервера
COPY --from=build /app/dist /usr/share/nginx/html
# Скопіюйте nginx налаштування в каталог для сервера
RUN rm /etc/nginx/conf.d/default.conf
COPY nginx/nginx.conf /etc/nginx/conf.d
# Відкрийте порт для сервера
EXPOSE 80

# Запустіть Nginx
CMD ["nginx", "-g", "daemon off;"]
=======
# ===== BUILD =====
FROM node:20-alpine AS build
WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npm run build

# ===== NGINX =====
FROM nginx:alpine

RUN rm /etc/nginx/conf.d/default.conf
COPY nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=build /app/dist /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
>>>>>>> efa2b52 (Updated docker and ngix)
