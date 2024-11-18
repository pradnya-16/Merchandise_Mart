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
import Payment from './components/Payment';
import './styles.css';
import ProductList from './components/ProductList';
import ProductDetails from './components/ProductDetails';

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
          <Route path="/" element={<ProductList />} />
        <Route path="/product/:id" element={<ProductDetails />} />
        <Route path="/cart" element={<Cart />} />
        <Route path="/payment" element={<Payment />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
