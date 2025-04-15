# On démarre d'une image de node légère
FROM node:alpine AS build

# On crée un dossier pour isoler le code de notre application du reste du conteneur
WORKDIR /app

# On copie les fichier contenant les dépendances
COPY package*.json ./

# On installe les dépendances
RUN npm install

# On ajoute le reste des fichiers de notre application à l'image
ADD . .

# On réalise un build de notre application React
RUN npm run build

# On utilise une autre image pour déployer le site web compilé précédemment
FROM nginx:stable-alpine

# On copie les fichiers du site web de l'étape précédente dans le répertoire contenant le site web par défaut sur NGINX
COPY --from=build /app/build /usr/share/nginx/html

# On informe les utilisateurs de notre image que le port 80 va avoir de l'importance
EXPOSE 80 

# On donne la commande d'entrée pour le conteneur lors d'un 'docker run'
CMD [ "nginx", "-g", "daemon off;" ]