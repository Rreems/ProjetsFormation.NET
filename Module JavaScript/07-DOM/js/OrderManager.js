import { Status } from "./interfaces.js";
export class OrderManager {
    constructor() {
        this.orders = [];
    }
    addOrder(order) {
        this.orders.push(order);
    }
    getOrderById(id) {
        return this.orders.find((order) => order.id == id);
    }
    updateOrderStatus(id, status) {
        let order = this.orders.find((order) => order.id == id);
        order.status = Status[status];
    }
    listOrdersByStatus(status) {
        return this.orders.filter((order) => order.status == Status[status]);
    }
    removeOrder(id) {
        this.orders = this.orders.filter((order) => order.id != id);
    }
}
