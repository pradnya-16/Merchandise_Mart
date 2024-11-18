import React from 'react';
import ProductItem from './ProductItem';

const productsData = {
  tshirts: Array.from({ length: 5 }, (_, i) => ({
    id: i + 11,
    name: `T-shirt ${i + 1}`,
    price: 15,
    imageUrl: `/images/tshirt${i + 1}.jpg`,
  })),
  hoodies: Array.from({ length: 5 }, (_, i) => ({
    id: i + 21,
    name: `Hoodie ${i + 1}`,
    price: 30,
    imageUrl: `/images/hoodie${i + 1}.jpg`,
  })),
  sweatshirts: Array.from({ length: 5 }, (_, i) => ({
    id: i + 31,
    name: `Sweatshirt ${i + 1}`,
    price: 25,
    imageUrl: `/images/sweatshirt${i + 1}.jpg`,
  })),
  joggers: Array.from({ length: 5 }, (_, i) => ({
    id: i + 41,
    name: `Jogger ${i + 1}`,
    price: 20,
    imageUrl: `/images/jogger${i + 1}.jpg`,
  })),
  accessories: Array.from({ length: 5 }, (_, i) => ({
    id: i + 51,
    name: `Accessory ${i + 1}`,
    price: 10,
    imageUrl: `/images/accessory${i + 1}.jpg`,
  })),
};

function ProductList() {
  return (
    <div className="product-categories">
      {Object.keys(productsData).map((category) => (
        <div key={category} className="category-section">
          <h2 className="category-title">{category.charAt(0).toUpperCase() + category.slice(1)}</h2>
          <div className="product-list">
            {productsData[category].map((product) => (
              <ProductItem key={product.id} product={product} />
            ))}
          </div>
        </div>
      ))}
    </div>
  );
}

export default ProductList;
