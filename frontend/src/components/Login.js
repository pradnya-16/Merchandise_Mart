import React, { useState } from 'react';
import { registerUser, loginUser } from '../api.js'; // Import API functions
import './Login.css';

function Login() {
  const [isSignUp, setIsSignUp] = useState(false);
  const [formData, setFormData] = useState({ name: '', email: '', password: '' });
  const [message, setMessage] = useState(''); // State for success/error messages

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      if (isSignUp) {
        // Call register API
        const response = await registerUser(formData);
        setMessage(response.data); // Show success message
      } else {
        // Call login API
        const response = await loginUser({ email: formData.email, password: formData.password });
        setMessage('Login successful!');
        localStorage.setItem('token', response.data.Token); // Save token to localStorage
      }
    } catch (error) {
      setMessage(error.response?.data || 'An error occurred');
    }
  };

  return (
    <div className="login-container">
      <div className="login-form">
        <h2>{isSignUp ? 'Sign Up' : 'Login'}</h2>
        <form onSubmit={handleSubmit}>
          {isSignUp && (
            <input
              type="text"
              name="name"
              placeholder="Name"
              value={formData.name}
              onChange={handleChange}
              required
            />
          )}
          <input
            type="email"
            name="email"
            placeholder="Email"
            value={formData.email}
            onChange={handleChange}
            required
          />
          <input
            type="password"
            name="password"
            placeholder="Password"
            value={formData.password}
            onChange={handleChange}
            required
          />
          <button type="submit">{isSignUp ? 'Sign Up' : 'Login'}</button>
        </form>
        <button className="switch-button" onClick={() => setIsSignUp(!isSignUp)}>
          {isSignUp ? 'Switch to Login' : 'Switch to Sign Up'}
        </button>
        {message && <p>{message}</p>}
      </div>
    </div>
  );
}

export default Login;
