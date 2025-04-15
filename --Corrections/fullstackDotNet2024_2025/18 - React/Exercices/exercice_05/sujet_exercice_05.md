# Exercice React 

## Objectif
Développer une application React qui utilise `useEffect()` pour afficher un message en fonction du résultat de la multiplication de deux nombres.

## Instructions

### 1. Configuration du Composant
- Le composant doit accepter une valeur numérique envoyée via les props.
- Créer deux variables d'état pour les champs de saisie (inputs) de type numérique.

### 2. Utilisation de `useEffect()`
- Utiliser `useEffect()` pour surveiller les changements dans les variables d'état des inputs.
- Le calcul effectué doit être la multiplication des deux nombres saisis.

### 3. Affichage Conditionnel
- Si le produit des deux nombres est égal à la valeur envoyée en props, afficher : 
  - "La multiplication des deux nombre fait bien XXX".
- Si le produit est différent, afficher :
  - "Les deux nombres multipliés ne font pas XXX...".

### 4. Gestion de l'Affichage du Message
- Utiliser une variable d'état de type booléen pour gérer l'affichage du message.
- Le message doit se mettre à jour automatiquement en fonction des entrées de l'utilisateur.