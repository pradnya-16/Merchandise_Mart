import React, { useState } from 'react';
import Modal from 'react-modal';
import { useCart } from '../CartContext';
import './ProductItem.css';

Modal.setAppElement('#root'); // Required for accessibility

function ProductItem({ product }) {
  const [isModalOpen, setModalOpen] = useState(false);
  const { addToCart } = useCart();

  const openModal = () => setModalOpen(true);
  const closeModal = () => setModalOpen(false);

  return (
    <div className="product-item">
      <img
        src={product.imageUrl}
        alt={product.name}
        className="product-image"
        onClick={openModal} // Open modal on image click
      />
      <h3>{product.name}</h3>
      <p>Price: ${product.price}</p>

      {/* Modal for expanded view */}
      <Modal
        isOpen={isModalOpen}
        onRequestClose={closeModal}
        className="product-modal"
        overlayClassName="modal-overlay"
      >
        <div className="modal-content">
          <img
            src={product.imageUrl}
            alt={product.name}
            className="modal-image"
          />
          <h2>{product.name}</h2>
          <p>Price: ${product.price}</p>
          <button
            className="add-to-cart-button"
            onClick={() => {
              addToCart(product);
              closeModal(); // Close modal after adding to cart
            }}
          >
            Add to Cart
          </button>
          <button
            className="buy-now-button"
            onClick={() => {
              alert('Proceeding to payment...'); // Replace with navigation to Payment
              closeModal();
            }}
          >
            Buy Now
          </button>
          <button className="close-button" onClick={closeModal}>
            Close
          </button>
        </div>
      </Modal>
    </div>
  );
}

export default ProductItem;
