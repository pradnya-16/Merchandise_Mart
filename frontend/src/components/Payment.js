import React, { useState } from 'react';
import { loadStripe } from '@stripe/stripe-js';
import { Elements, CardElement, useStripe, useElements } from '@stripe/react-stripe-js';
import './Payment.css';

// Load Stripe with your publishable key
const stripePromise = loadStripe('pk_test_51QMcBgELN7EfHzd3PuMN61SJzcRKjeVSdWcPrHdCc7sekN2tpGqKdyHYANvQtOJFvasBy8cQ2jEt0XBJslYob6Pd00d0C6coWb');

function Payment({ totalAmountInCents }) {
  const [isProcessing, setIsProcessing] = useState(false);

  return (
    <div className="payment-container">
      <h2>Payment</h2>
      <Elements stripe={stripePromise}>
        <CheckoutForm
          totalAmountInCents={totalAmountInCents}
          isProcessing={isProcessing}
          setIsProcessing={setIsProcessing}
        />
      </Elements>
    </div>
  );
}

function CheckoutForm({ totalAmountInCents, isProcessing, setIsProcessing }) {
  const stripe = useStripe();
  const elements = useElements();
  const [errorMessage, setErrorMessage] = useState('');

  const handleSubmit = async (event) => {
    event.preventDefault();
    setIsProcessing(true);

    if (!stripe || !elements) return;

    const cardElement = elements.getElement(CardElement);

    try {
      const response = await fetch('http://localhost:5000/api/payments/create-payment-intent', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ amount: totalAmountInCents }), // Dynamic amount passed here
      });

      const data = await response.json();

      if (!data.clientSecret) {
        setErrorMessage("Failed to fetch client secret");
        setIsProcessing(false);
        return;
      }

      const paymentResult = await stripe.confirmCardPayment(data.clientSecret, {
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
      <CardElement
        className="card-element"
        options={{
          style: {
            base: {
              fontSize: '16px',
              color: '#424770',
              '::placeholder': { color: '#aab7c4' },
            },
            invalid: { color: '#9e2146' },
          },
          hidePostalCode: true,
        }}
      />
      <button type="submit" disabled={!stripe || isProcessing} className="payment-button">
        {isProcessing ? 'Processing...' : 'Pay Now'}
      </button>
      {errorMessage && <p className="error-message">{errorMessage}</p>}
    </form>
  );
}

export default Payment;
