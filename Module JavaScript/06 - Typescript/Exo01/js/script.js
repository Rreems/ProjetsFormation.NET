import { createBook } from "./fonctions.js";
import { Library } from "./Library.js";
const author1 = {
    name: "Toto",
    birthYear: new Date("1995-12-17T03:24:00"),
    genres: ["Fantasy", "Horror"]
};
const book1 = createBook("SuperPeur1", author1, 121);
const library = new Library();
library.addBook(book1);
console.log(library.listAvailableBooks());
