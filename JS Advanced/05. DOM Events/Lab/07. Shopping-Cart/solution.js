function solve() {
   let shoppingCart = document.getElementsByClassName('shopping-cart')[0];
   let result = document.getElementsByTagName('textarea')[0];

   let products = [];
   let totalPrice = 0;
   let checkoutDone = false;

   shoppingCart.addEventListener('click', function(event) {
      if (event.target.nodeName !== 'BUTTON') {
         return;
      }

      if (checkoutDone) {
         return;
      }

      let btn = event.target;

      if (Array.from(btn.classList).indexOf('add-product') >= 0) {
         let productElement = event.target.parentElement.parentElement;

         let productName = productElement.querySelectorAll('.product-title')[0].textContent;
         let productPrice = productElement.querySelectorAll('.product-line-price')[0].textContent;

         result.textContent += `Added ${productName} for ${productPrice} to the cart.\n`;

         if (products.indexOf(productName) < 0) {
            products.push(productName);
         }

         totalPrice += Number(productPrice);
      } else if (Array.from(btn.classList).indexOf('checkout' >= 0)) {
         result.textContent += `You bought ${products.join(', ')} for ${totalPrice.toFixed(2)}.`
         checkoutDone = true;
      }
   }); 
}