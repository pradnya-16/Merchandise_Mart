import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

function Header() {
  const [query, setQuery] = useState('');
  const navigate = useNavigate();

  const handleSearch = (e) => {
    e.preventDefault();
    navigate(`/?search=${query}`);
  };

  return (
    <header>
      <h1>Merchandise Mart</h1>
      <nav>
        <Link to="/">Home</Link>
        <Link to="/about">About</Link>
        <Link to="/cart">Cart</Link>
        <Link to="/login">Login</Link>
      </nav>
      <form onSubmit={handleSearch}>
        <input 
          type="text" 
          placeholder="Search for products..." 
          value={query} 
          onChange={(e) => setQuery(e.target.value)} 
        />
        <button type="submit">Search</button>
      </form>
    </header>
  );
}

export default Header;
