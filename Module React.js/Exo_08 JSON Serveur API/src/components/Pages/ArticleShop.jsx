
import { useOutletContext } from 'react-router-dom';
import ArticleDisplay from "../ArticleDisplay.jsx"

const ArticleShop = () => {

    const [listArticle, setListArticle, data] = useOutletContext();
    // console.log("Data en Shop:");
    // console.log(data);
    return (
        <>
            {
                data && (
                    <div className="flex-container">
                        {
                            data.map(article => (
                                <ArticleDisplay articleId={article.id}></ArticleDisplay>
                                // <div key={article.id}>
                                //     <li>
                                //         {article.name}
                                //     </li>
                                // </div>

                            ))
                        }
                    </div>


                )
            }
        </>
    );
}

export default ArticleShop;