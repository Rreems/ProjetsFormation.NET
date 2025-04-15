import { Author, Book } from "./interface.js";

export function createBook(title: string, author: Author, pages: number): Book {
    return {
        title: title,
        author: author,
        pages: pages,
        isAvailable: true
    }
}

export function toggleAvailability(book: Book): void {
    book.isAvailable = !book.isAvailable
}