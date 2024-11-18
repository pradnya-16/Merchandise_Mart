// src/App.js
import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import Header from './components/Header';
import Home from './components/Home';
import Login from './components/Login';
import Cart from './components/Cart';
import About from './components/About';
import Checkout from './components/Checkout';
import ProductList from './components/ProductList';
import ProductDetails from './components/ProductDetails';
import Payment from './components/Payment';
import { loadStripe } from "@stripe/stripe-js";
import { Elements } from "@stripe/react-stripe-js";
import './styles.css';

// Load Stripe
const stripePromise = loadStripe("pk_test_51QMcBgELN7EfHzd3PuMN61SJzcRKjeVSdWcPrHdCc7sekN2tpGqKdyHYANvQtOJFvasBy8cQ2jEt0XBJslYob6Pd00d0C6coWb"); // Replace with your Stripe Publishable Key

function App() {
  return (
    <Router>
      <div>
        <Header />
        <ToastContainer />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/cart" element={<Cart />} />
          <Route path="/about" element={<About />} />
          <Route path="/checkout" element={<Checkout />} />
          <Route path="/product" element={<ProductList />} />
          <Route path="/product/:id" element={<ProductDetails />} />
          <Route
            path="/payment"
            element={
              <Elements stripe={stripePromise}>
                <Payment totalAmount={100} /> {}
              </Elements>
            }
          />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
