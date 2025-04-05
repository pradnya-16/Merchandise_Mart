import React from 'react';
import Payment from './Payment';

function Checkout() {
  const totalAmount = 5000; // Replace this with your dynamic total amount in cents

  return (
    <div>
      <h2>Checkout</h2>
      <p>Total: $50.00</p>
      <Payment totalAmountInCents={totalAmount} />
    </div>
  );
}

export default Checkout;
