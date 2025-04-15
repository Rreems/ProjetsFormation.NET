# On part d'une image de node allégée
FROM node:alpine

# On crée un dossier de travail pour isoler l'application du reste du conteneur
WORKDIR /app

# On copie les fichiers contenant les dépendances
ADD package*.json ./

# On installe les dépendances
RUN npm install

# On copie les fichiers de l'application
COPY . .

# On informe que le port 3000 va être utilisé
EXPOSE 3000

# La commande d'entrée au lancement du conteneur sera...
CMD [ "npm", "start" ]