import { OrderManager } from "./OrderManager.js";
import { createOrder } from "./functions";
const testBtn = document.querySelector(".content");
const div = document.querySelector(".content");
let frites = {
    id: "5",
    name: "Frites",
    price: 1.30,
    stock: 154
};
let burger = {
    id: "6",
    name: "Burger",
    price: 4.50,
    stock: 42
};
let marc = {
    id: "15",
    name: "Marc",
    email: "marc.zuper@mail.com"
};
let orderItem1 = {
    product: frites,
    quantity: 3
};
let orderItem2 = {
    product: burger,
    quantity: 2
};
let orderMarc = createOrder(marc, [orderItem1, orderItem2]);
let orderId = orderMarc.id;
const MississipiBurger = new OrderManager();
console.log("Step 1: new orderManager  ");
console.log(MississipiBurger);
MississipiBurger.addOrder(orderMarc);
console.log("Step 2: Order marc associée  ");
console.log(MississipiBurger);
console.log("Step 3: Get order  ");
console.log(MississipiBurger.getOrderById(orderId));
MississipiBurger.updateOrderStatus(orderId, "expédiée");
console.log("Step 3: Update status  ");
console.log(MississipiBurger.getOrderById(orderId));
// listOrdersByStatus(status: 'en attente' | 'expédiée' | 'livrée'): Order[] { //retourne toutes les commandes ayant le statut spécifié.
//  removeOrder(id: string): void { // dans la classe OrderManager qui supprime une commande par son identifiant.
