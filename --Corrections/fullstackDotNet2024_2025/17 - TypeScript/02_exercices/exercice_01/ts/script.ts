import { createBook, toggleAvailability } from "./fonctions.js";
import { Author} from "./interface.js";
import { Library } from "./Library.js";

const author1: Author = {
    name : "Toto",
    birthYear: 2000,
    genres: ["Fantasy", "Drama"]
}

const author2: Author = {
    name : "Tata",
    birthYear: 1990,
    genres: ["Aventure"]
}

const book1 = createBook("livre 1", author2, 200)
const book2 = createBook("livre 2", author1, 500)
const book3 = createBook("livre 3", author2, 300)

const library = new Library()

library.addBook(book1)
library.addBook(book2)
library.addBook(book3)

console.log(library.listAvailableBooks());

toggleAvailability(book2)

console.log(library.listAvailableBooks());

console.log(library.findBookByTitle("livre 3"));

console.log(library.getBooksByAuthor("Tata"));

library.removeBook("livre 1")
console.log(library.findBookByTitle("livre 1"));