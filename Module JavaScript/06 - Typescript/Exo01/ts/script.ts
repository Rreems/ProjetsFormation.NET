import { createBook, toggleAvailability } from "./fonctions.js";
import { Author, Book } from "./interfaces.js";
import { Library } from "./Library.js";

const author1: Author = {
    name: "Toto",
    birthYear: new Date("1995-12-17T03:24:00"),
    genres: ["Fantasy", "Horror"]
}

const book1 : Book = createBook("SuperPeur1" , author1, 121);

const library = new Library()

library.addBook(book1)

console.log(library.listAvailableBooks());