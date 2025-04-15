export class Library {
    constructor() {
        this.books = [];
    }
    addBook(book) {
        this.books.push(book);
    }
    removeBook(title) {
        this.books = this.books.filter(book => book.title != title);
    }
    findBookByTitle(title) {
        return this.books.find(book => book.title == title);
    }
    listAvailableBooks() {
        return this.books.filter(book => book.isAvailable);
    }
    getBooksByAuthor(authorName) {
        return this.books.filter(book => book.author.name == authorName);
    }
}
