// Partie 1

interface Product {
    id: number
    name: string
    price: number
    stock: number
}

interface Customer {
    id: number
    name: string
    email: string
}

interface OrderItem {
    product: Product
    quantity: number
}

type Status = 'en attente' | 'livrée' | 'expédiée'

interface Order {
    id: number
    customer: Customer
    items: OrderItem[]
    status: Status
}

// Partie 2

function createOrder(customer: Customer, items: OrderItem[]) : Order {
    return {
        id: Math.random(),
        customer: customer,
        items: items,
        status: 'en attente'
    }
}

function calculTotal(order: Order) : number {
    return order.items.reduce((total, item) => total + item.product.price * item.quantity,0)
}

// Partie 3

class OrderManager {
    orders : Order[] = []

    addOrder(order: Order) : void {
        this.orders.push(order)
    }

    getOrderById(id: number): Order | undefined {
        return this.orders.find(order => order.id === id)
    }

    updateOrderStatus(id: number, status: Status) : void {
        const order = this.getOrderById(id)
        if(order) {
            order.status = status
        }
    }

    listOrdersByStatus(status: Status): Order[] {
        return this.orders.filter(order => order.status === status)
    }

    removeOrder(id: number): void {
        this.orders = this.orders.filter(order => order.id !== id)
    }
}

const product1: Product = {id: 1, name: 'pc', price: 500, stock: 2}
const product2: Product = {id: 2, name: 'souris', price: 50, stock: 10}

const customer: Customer = {
    id: 1,
    name: "toto",
    email: "toto@email.fr"
}

const orderItem: OrderItem = {
    product: product1,
    quantity: 2
}

const order: Order = createOrder(customer, [orderItem])

const orderManager = new OrderManager();
orderManager.addOrder(order)

console.log(calculTotal(order));