import { Button } from 'bootstrap';
import { useOutletContext, Link } from 'react-router-dom'

const articleDisplay = ({ articleId }) => {

    const [articleList, setArticleList, data] = useOutletContext()
    const article = data.find(article => article.id == articleId)

    const addPanier = () => {
        const articleEnList = articleList.find(article => article.id == articleId)

        if (articleEnList) {
            articleEnList.quantity++ ; 
            setArticleList(prev => prev.map(article => article.id == articleEnList.id ? articleEnList : article))

        } else {
            setArticleList(oldArray => [...oldArray, {
                id: article.id,
                name: article.name,
                description: article.description,
                price: article.price,
                quantity: 1
            }]);
        }
        console.log("Ajout ok. Liste en Display:");
        console.log(articleList);
    }


    // console.log("Data en ArticleDisplay");
    // console.log(data);
    // console.log("Id en Display:");
    // console.log(articleId);
    // console.log("Article en Display:");
    // console.log(article);

    return (
        <>
            <div>
                <h3>{article.name}</h3>
                <p> {article.description}</p>
                <p>Prix : {article.price}€</p>
                <button onClick={addPanier}>Ajouter au panier</button>
            </div>
        </>
    );
}

export default articleDisplay;