# Créer une application React 
npx create-react-app exercice08-app

# Créer un Dockerfile pour notre application

# Créer une image pour notre application
docker build -t exercice08-app .

# Déployer dans un conteneur l'image de notre application
docker run -d -p 80:3000 exercice08-app

# Vérifier son accessibilité au moyen de `http://localhost`