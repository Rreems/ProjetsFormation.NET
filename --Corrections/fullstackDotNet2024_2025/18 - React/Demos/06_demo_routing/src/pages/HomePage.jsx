import { Link, useOutletContext } from "react-router-dom";

const HomePage = () => {

    console.log(useOutletContext());
    return ( 
        <>
            <h1>HomePage</h1>
            <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eaque, autem. Laboriosam dolorem quidem ipsum animi in magnam dolore esse ut architecto dolores? Aperiam mollitia maiores omnis eius nisi autem quidem.
            Odio nesciunt sequi voluptas, earum nisi temporibus similique, eligendi quas ullam praesentium atque molestiae distinctio labore repellat corrupti, perspiciatis ut cum. Enim, laborum. Repellat reprehenderit quisquam voluptate tempore, quos necessitatibus?
            Architecto ab aliquid optio voluptatibus tempore aspernatur, eveniet adipisci repudiandae cumque soluta eum iure obcaecati at incidunt. Deleniti, nulla quaerat nesciunt porro aspernatur, accusamus eveniet sint doloremque maiores mollitia voluptas?
            Quod eligendi possimus fugiat rerum fuga accusantium, cumque quas odit doloribus impedit suscipit ipsum quis. Dolorem tempora odit provident enim, quibusdam ratione aliquid. Quia suscipit, sit vel id voluptate nobis?
            Ipsam, placeat adipisci excepturi, porro suscipit blanditiis a necessitatibus dolor numquam voluptatibus recusandae similique rerum incidunt in. Accusantium, pariatur nemo qui ullam enim sapiente dolores. Delectus incidunt nihil mollitia sapiente!
            Quaerat, sit adipisci ut aperiam aliquid asperiores corrupti dolor beatae ad, similique quibusdam voluptatem quisquam blanditiis aut neque officiis minus soluta odit consectetur cupiditate ullam! Adipisci natus sequi facilis iusto.
            Vero, iste quae deleniti temporibus veritatis ea, mollitia eligendi facere animi assumenda fuga nesciunt, aut natus officia veniam molestias odit voluptatum expedita quidem sint velit praesentium sed ut. Saepe, voluptatibus.
            Sed quidem enim aliquid dolore libero quisquam error rerum. Consequatur totam aspernatur id unde fugit. Quo ipsam, maiores aperiam eaque autem quis iusto laborum, magnam, dolorum dolore reiciendis minus sed?
            Corrupti, voluptate a voluptas voluptatum quo quia. Consectetur error quasi vero officiis enim, ut delectus necessitatibus aperiam sed! Sunt, ullam nostrum tempora eum ducimus blanditiis molestias hic autem molestiae dicta.
            Molestiae quod perspiciatis facere, id veritatis beatae aut tempora quis nulla? Ab cum voluptatibus voluptate neque sit qui ipsam optio! Possimus blanditiis voluptas tempora beatae consequatur aperiam. Ad, perferendis reprehenderit!</p>
            <Link to={"/profil/1?mode=1&darkMode=true"}>Toto</Link>
            <Link to={"/profil/2"}>Tata</Link>
            <Link to={"/profil/3"}>Titi</Link>
        </>
     );
}
 
export default HomePage;