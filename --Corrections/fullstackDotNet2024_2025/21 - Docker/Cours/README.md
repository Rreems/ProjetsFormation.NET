# Cours Docker 

## Commandes de base 

* Lister les conteneurs 

```bash
docker ps
docker container ls

# Pour avoir les stoppés
docker ps -a 
docker container ls -a
```

* Lancer un conteneur 

```bash
docker run <image-name>
```

`-d` Pour le lancer en détaché

`-i` Pour le lancer en liant l'entrée standard à celle du conteneur

`-t` Pour activer les profils TTY

`--name` Pour le nommer

`-p <port-host>:<port-container>` Pour lier les ports hôtes à ceux du conteneur

`-v <volume-name | path>:<path>` Pour créer un volume (anonyme / nommé) ou un bindmount (si chemin dans partie gauche) pour le conteneur

`-e <variable-name>=<variable-value>` Pour ajouter des variables d'environement à notre conteneur

`--rm` Pour supprimer le conteneur en cas d'arret
`--network <network-name>` Pour brancher le conteneur à un réseau

* Lister les images

```bash
docker images

docker image ls
```

* Supprimer une image

```bash
docker rmi <id-image | image-name>
```

* Récupérer une image sur Dockerhub

```bash
docker pull <image-name>
```

* Stopper un conteneur 

```bash
docker stop <id-container>
```

* Supprimer un conteneur

```bash
docker rm <id-container>
```

`-f` Pour forcer l'arret des conteneur en amont

* Supprimer toutes les ressources d'un type

```bash
docker <resource-name> prune
```

`-f` Pour forcer la suppression sans le prompt de confirmation

* Relancer un conteneur stoppé 

```bash
docker start <id-container>
```

* Exécuter une commande dans un conteneur 

```bash
docker exec <id-container> <command>
```

* Créer un réseau pour nos conteneurs 

```bash
docker network create <network-name>
```

* Build une image docker 

```bash
docker build -t <image-name> <dockerfile-path>
```

## Création de Dockerfiles

```dockerfile
# Pour choisir une image de départ
FROM <image-name>

# Il est possible de nommer nos étapes de sorte à les réutiliser par la suite dans le Dockerfile
FROM <image-name> AS <stage-name>

# Pour copier des fichiers dans l'image de fin
COPY <host-path> <contaùiner-path>

# Pour copier des fichiers depuis une ancienne étape de notre build, on peut ajouter `--from=<stage-name>`
COPY --from=<stage-name> <stage-a-path> <stage-b-path>

# Pour ajouter des fichiers (et potentiellement les traiter, telle une archive à extraire dés le début) à l'image
ADD <host-path> <container-path>

# Choisir un dossier de travail (le créer au besoin)
WORKDIR <host-directory-path>

# Créer, si non existant, et se connecter en tant que tel utilisateur pour la suite des instructions de build
USER <user-name>

# Exécuter une commande durant la phase de build
RUN ["command", "args", "args..."]
RUN command args args...

# Pour informer de l'utilisation d'un port par l'application, on peut utiliser cette instruction
EXPOSE <port>

# Choisir la commande de lancement de notre conteneur lors d'un 'docker run'
CMD ["command", "args..."]

# Choisir la commande de lancement (verrouillée à commencer par la valeur) de notre conteneur lors d'un 'docker run'
ENTRYPOINT ["command"]


```