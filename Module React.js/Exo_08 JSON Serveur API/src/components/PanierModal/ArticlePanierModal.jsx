import { useOutletContext } from 'react-router-dom'


const ArticlePanierModal = ({Id, context}) => {

    const [listArticle, setListArticle, data] = context;

    const removeFromPanier = (Id) => {
        setListArticle(prev => prev.filter(article => article.id != Id))
    }

    const article = listArticle.find(article => article.id == Id)


    return (
        <>
            <div key={Id}>
                <li className="list-group-item">
                    {article.name} <br />
                    Prix: {article.price} <br />


                    [Quantité: {article.quantity}] <br />

                    {/* <button onClick={removeFromPanier(article.id)} type="button" className="btn btn-danger">Supprimer</button> */}
                    {/* onClick={removeFromPanier(article.id)} */}

                    <button onClick={() => {console.log("supp");}} type="button" className="btn btn-danger">Supprimer</button>
                </li>
            </div>
        </>
    );
}

export default ArticlePanierModal;