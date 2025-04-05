import axios from 'axios';

// Base URL of your backend
const API = axios.create({ baseURL: 'http://localhost:5002/api' });

// User Endpoints
export const registerUser = (userData) => API.post('/users/register', userData);
export const loginUser = (userData) => API.post('/users/login', userData);

// Product Endpoints
export const getProducts = () => API.get('/products');

// Order Endpoints
export const placeOrder = (orderData) => API.post('/orders', orderData);

export default API;
