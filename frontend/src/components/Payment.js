import React, { useState } from 'react';
import { loadStripe } from '@stripe/stripe-js';
import { Elements, CardElement, useStripe, useElements } from '@stripe/react-stripe-js';
import './Payment.css';

// Load Stripe with your publishable key
const stripePromise = loadStripe('your-publishable-key-here');

function Payment() {
  const [isProcessing, setIsProcessing] = useState(false);

  return (
    <div className="payment-container">
      <h2>Payment</h2>
      <Elements stripe={stripePromise}>
        <CheckoutForm isProcessing={isProcessing} setIsProcessing={setIsProcessing} />
      </Elements>
    </div>
  );
}

function CheckoutForm({ isProcessing, setIsProcessing }) {
  const stripe = useStripe();
  const elements = useElements();
  const [errorMessage, setErrorMessage] = useState('');

  const handleSubmit = async (event) => {
    event.preventDefault();
    setIsProcessing(true);

    if (!stripe || !elements) return;

    const cardElement = elements.getElement(CardElement);

    try {
      // Call backend to create a payment intent
      const response = await fetch('http://localhost:5000/create-payment-intent', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ amount: 5000 }), // Replace 5000 with dynamic totalAmount in cents
      });
      const { clientSecret } = await response.json();

      const paymentResult = await stripe.confirmCardPayment(clientSecret, {
        payment_method: { card: cardElement },
      });

      if (paymentResult.error) {
        setErrorMessage(paymentResult.error.message);
      } else {
        alert('Payment successful!');
      }
    } catch (error) {
      setErrorMessage('Payment failed. Try again.');
    } finally {
      setIsProcessing(false);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="checkout-form">
      <CardElement className="card-element" />
      <button type="submit" disabled={!stripe || isProcessing} className="payment-button">
        {isProcessing ? 'Processing...' : 'Pay Now'}
      </button>
      {errorMessage && <p className="error-message">{errorMessage}</p>}
    </form>
  );
}

export default Payment;
