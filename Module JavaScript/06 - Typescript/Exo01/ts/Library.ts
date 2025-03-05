import { Book } from "./interfaces.js";

export class Library {

    private books: Book[] = []

    addBook(book: Book): void {  //ajoute un livre à la bibliothèque.
        this.books.push(book);
    }

    removeBook(title: string): void { // supprime un livre par son titre.
        this.books = this.books.filter(book => book.title != title)
    }

    findBookByTitle(title: string): Book | undefined { //renvoie le livre avec le titre correspondant.
        return this.books.find(book => book.title == title)
    }


    listAvailableBooks(): Book[] { // renvoie un tableau de livres disponibles.
        return this.books.filter(book => book.isAvailable)
    }

    getBookByAuthor(authorName: string): Book[] {
        return this.books.filter(book => book.author.name = authorName)
    }
}