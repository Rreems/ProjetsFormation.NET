
export interface Product{
    id: string
    name : string
    price: number
    stock: number
}

export interface Customer{
    id: string
    name: string
    email: string
}

export interface OrderItem{
    product: Product
    quantity: number
}

export interface Order{
    id: string
    customer: Customer
    items: OrderItem[]
    status: Status  //  ou: "en attente" | "expédiée" | "livrée"
}

export enum Status {
    "en attente", 
    "expédiée", 
    "livrée"
  }