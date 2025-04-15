### Exercice 2 TypeScript

#### Contexte
Vous êtes en train de développer une application pour gérer les commandes dans une boutique en ligne. Vous devez créer un ensemble de classes, interfaces, types, et fonctions pour modéliser les produits, les clients, les commandes, et les opérations possibles sur ces commandes.

#### Partie 1 : Types de base et Interfaces
1. **Créez une interface `Product`** pour représenter un produit. Un produit a un identifiant (`id`), un nom (`name`), un prix (`price`), et un stock (`stock`) indiquant le nombre d'unités disponibles.

2. **Créez une interface `Customer`** pour représenter un client. Un client a un identifiant (`id`), un nom (`name`), et un email (`email`).

3. **Créez une interface `OrderItem`** pour représenter un article dans une commande. Un `OrderItem` contient un produit (`product` de type `Product`) et une quantité (`quantity`).

4. **Créez une interface `Order`** pour représenter une commande. Une commande a un identifiant (`id`), un client (`customer` de type `Customer`), un tableau d'articles (`items` de type `OrderItem[]`), et un statut (`status`) qui peut être soit "en attente", "expédiée", ou "livrée".

#### Partie 2 : Fonctions
1. **Créez une fonction `createOrder`** qui prend un client, un tableau d'articles, et retourne une nouvelle commande avec le statut par défaut à "en attente".

2. **Créez une fonction `calculateTotal`** qui prend une commande et retourne le montant total de la commande en fonction des produits et des quantités.

#### Partie 3 : Classes
1. **Créez une classe `OrderManager`** pour gérer les commandes. Cette classe doit avoir un tableau de commandes (`orders`) et les méthodes suivantes :
   - `addOrder(order: Order)`: ajoute une commande à la liste.
   - `getOrderById(id: string)`: retourne la commande correspondant à l'identifiant donné.
   - `updateOrderStatus(id: string, status: 'en attente' | 'expédiée' | 'livrée')`: met à jour le statut de la commande correspondante.
   - `listOrdersByStatus(status: 'en attente' | 'expédiée' | 'livrée')`: retourne toutes les commandes ayant le statut spécifié.

2. **Créez une méthode `removeOrder(id: string)`** dans la classe `OrderManager` qui supprime une commande par son identifiant.

#### Partie 4 : Test
1. **Instanciez la classe `OrderManager`** et ajoutez plusieurs commandes.
  
2. **Testez les différentes méthodes** de la classe `OrderManager` pour vérifier leur bon fonctionnement (ajout, mise à jour du statut, calcul du total, suppression, etc.).