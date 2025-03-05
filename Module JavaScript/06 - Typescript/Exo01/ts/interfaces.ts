

export interface Author {
    name: string
    birthYear: Date
    genres: string[]
}

export interface Book {

    title: string
    author: Author
    pages: number
    isAvailable : boolean
}