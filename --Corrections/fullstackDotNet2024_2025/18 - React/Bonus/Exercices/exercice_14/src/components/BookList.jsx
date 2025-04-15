import { useEffect, useState } from "react";
import axios from "axios"
import { Link } from "react-router-dom";

const BookList = () => {
  const [books, setBooks] = useState([])

  useEffect(() => {
    axios.get("https://openlibrary.org/subjects/science_fiction.json?limit=20")
    .then(response => {
      setBooks(response.data.works)
      console.log(response.data.works);
    })
  }, [])

  return ( 
    <>
      <h1 className="text-center m-4">Liste des livres</h1>
      <div className="row">
        {
          books.map(book => (
            <div className="col-md-4 mb-4" key={book.key}>
              <Link to={`/details/${book.key.replace("/works/", "")}`} className="d-block text-decoration-none text-dark">
                <img src={`https://covers.openlibrary.org/b/id/${book.cover_id}-L.jpg`} alt={book.title} className="img-fluid mx-auto d-block" />
                <p className="text-center"><b>{book.title}</b></p>
              </Link>
            </div>
          ))
        }
      </div>
    </>
   );
}
 
export default BookList;