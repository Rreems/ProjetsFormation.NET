import { useEffect, useRef, useState } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios'
import './App.css'

function App() {
  const [countries, setCountries] = useState([])
  const [filteredCountries, setFilteredCountries] = useState([])
  const searchCountryRef = useRef('')

  useEffect(() => {
    axios.get("https://restcountries.com/v3.1/all")
      .then(res => {
        setCountries(res.data)
        setFilteredCountries(res.data)
        console.log(res.data);
      })
  }, [])

  const handleSearch = () => {
    const searchCountry = searchCountryRef.current.value.toLowerCase()
    setFilteredCountries(countries.filter(country => country.translations.fra.official.toLowerCase().includes(searchCountry))) 
  }

  return (
    <div className='container'>
      <h1>Liste des pays</h1>
      <input type="text" ref={searchCountryRef} onChange={handleSearch} className='form-control mb-4'/>
      <div className='row'>
        {
          filteredCountries.map(country => (
            <div className='col-md-4 mb-4' key={country.name.common}>
              <div className='card'>
                  <img src={country.flags.png} alt={country.translations.fra.official} className='card-img-top' style={{height: "200px", width: "100%", objectFit: 'cover'}} />
                <div className='card-body'>
                  <h3 className='card-title'>{country.translations.fra.official}</h3>
                  <p>Région : {country.region}</p>
                  <p>Capitale : {country.capital}</p>
                  <p>Population : {country.population}</p>
                </div>
              </div>
            </div>
          ))
        }
      </div>
    </div>
  )
}

export default App
