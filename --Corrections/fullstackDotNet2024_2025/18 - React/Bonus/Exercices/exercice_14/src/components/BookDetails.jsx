import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Markdown from "react-markdown"
import axios from 'axios'

const BookDetails = () => {
  const {id} = useParams()
  const [bookDetails, setBookDetails] = useState(null)
  const [authorNames, setAuthorNames] = useState(null)

  useEffect(() => {
    axios.get(`https://openlibrary.org/works/${id}.json`)
    .then(response => {
      setBookDetails(response.data)
      console.log(response.data);
      axios.get(`https://openlibrary.org${response.data.authors[0].author.key}.json`)
      .then(response => {
        console.log(response.data);
        setAuthorNames(response.data.name)
      })
    })

  }, [])

  return ( 
    <div className="card bg-dark text-light border border-light rounded m-4">
      <div className="card-header d-flex align-items-center">
        <h2>Détails du livre</h2>
      </div>
      <div className="d-flex justify-content-center">
        <img src={`https://covers.openlibrary.org/b/id/${bookDetails?.covers[0]}-L.jpg`} alt={bookDetails?.title} className="img-fluid" />
      </div>
      <div className="card-body">
        <ul className="list-group list-group-flush">
          <li className="list-group-item bg-dark text-light"><b>Titre : </b>{bookDetails?.title}</li>
          <li className="list-group-item bg-dark text-light"><b>Auteur : </b>{authorNames}</li>
          <li className="list-group-item bg-dark text-light"><b>Date de publication : </b>{bookDetails?.first_publish_date}</li>
          <li className="list-group-item bg-dark text-light"><b>Description : </b><Markdown>{bookDetails?.description}</Markdown></li>
        </ul>
      </div>
    </div>
   );
}
 
export default BookDetails;