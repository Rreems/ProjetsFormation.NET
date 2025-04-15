// Partie 1

export interface Author {
    name: string
    birthYear: number
    genres: string[]
}

export interface Book {
    title: string
    author: Author
    pages: number
    isAvailable: boolean
}