export function createBook(title, author, pages) {
    return {
        title: title,
        author: author,
        pages: pages,
        isAvailable: true
    };
}
export function toggleAvailability(book) {
    book.isAvailable = !book.isAvailable;
}
