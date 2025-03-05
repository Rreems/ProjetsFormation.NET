import { Status } from "./interfaces.js";
export function createOrder(customer, oderItems) {
    return {
        id: Math.floor(Math.random() * 1000).toString(),
        customer: customer,
        items: oderItems,
        status: Status["en attente"]
    };
}
export function calculateTotal(order) {
    let sum = 0;
    order.items.forEach((item) => {
        sum += item.product.price * item.quantity;
    });
    return sum;
}
