import { Order, Status } from "./interfaces.js";


export class OrderManager {
    private orders: Order[] = [];


    addOrder(order: Order): void {//ajoute une commande à la liste.
        this.orders.push(order);
    }

    getOrderById(id: string): Order | undefined { //retourne la commande correspondant à l'identifiant donné.
        return this.orders.find((order) => order.id == id);
    }


    updateOrderStatus(id: string, status: "en attente" | "expédiée" | "livrée"): void { //met à jour le statut de la commande correspondante.
        let order = this.getOrderById(id);
        if(order) order.status = Status[status]
    }

    listOrdersByStatus(status: 'en attente' | 'expédiée' | 'livrée'): Order[] { //retourne toutes les commandes ayant le statut spécifié.
        return this.orders.filter((order) => order.status == Status[status])
    }

     removeOrder(id: string): void { // dans la classe OrderManager qui supprime une commande par son identifiant.
        this.orders = this.orders.filter((order) => order.id != id);
     }
}