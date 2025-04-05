import React from 'react';
import ProductList from './ProductList';
import './Home.css';

function Home() {
  return (
    <div className="home-container">
      <h2 className="home-heading">Our Collection</h2>
      <ProductList />
    </div>
  );
}

export default Home;
