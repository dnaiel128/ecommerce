import { defineStore } from 'pinia'

export const cartStore = defineStore('cart', {
  state: ()=>({
    cart: []
  }),

  actions:{
    async addToCart (product,logged,productQuantity) {
      let user = JSON.parse(localStorage.getItem('user'));
      
      let quantity = 1
      if((productQuantity != null) || (productQuantity>1)) { quantity = productQuantity} 

      if(logged){
        await fetch("https://localhost:7113/cart", {
          method: "POST",
          body: JSON.stringify({
            UserId:user.id,
            ItemId:product.id,
            Quantity:quantity
          }),
          headers: {
            "Content-type": "application/json; charset=UTF-8",
            "Access-Control-Allow-Origin": "*",
          }
        })
      }
      this.cart.push({
        item:product,
        quantity:quantity
      });
    },

    async removeFromCart(id,logged) {
      let user = JSON.parse(localStorage.getItem('user'));
      let product = this.cart.find((item)=>item.item.id=id);

      if(logged){
        await fetch("https://localhost:7113/cart", {
          method: "DELETE",
          body: JSON.stringify({
            UserId:user.id,
            ItemId:product.item.id,
            Quantity:product.quantity
          }),
          headers: {
            "Content-type": "application/json; charset=UTF-8",
            "Access-Control-Allow-Origin": "*",
          }
        })
      }
      this.cart = this.cart.filter((item) => item.item.id !== id)
    },

    async emptyCart(logged) {
      let user = JSON.parse(localStorage.getItem('user'));
      if(logged){
        await fetch("https://localhost:7113/cart/clearCart?userId="+user.id, {
          method: "DELETE",
          headers: {
            "Content-type": "application/json; charset=UTF-8",
            "Access-Control-Allow-Origin": "*",
          }
        })
      }
      this.cart = []
    },

    async addBulk () {
      let user = JSON.parse(localStorage.getItem('user'));
      let cartedItems = []
      this.cart.forEach(item => {
        cartedItems.push({
          UserId:user.id,
          ItemId:item.item.id,
          Quantity:item.quantity
        })
      });
      await fetch("https://localhost:7113/cart/addBulk", {
        method: "POST",
        body: JSON.stringify(cartedItems),
        headers: {
          "Content-type": "application/json; charset=UTF-8",
          "Access-Control-Allow-Origin": "*",
        }
      })
    },
    async updateQuantity(id,logged,inc){

      let user = JSON.parse(localStorage.getItem('user'));

      let product = this.cart.find((item)=>item.item.id==id);
      
      let newQuantity = product.quantity;
      if(inc) { newQuantity += 1; }
      else { newQuantity -= 1; }

      if(logged){
        await fetch("https://localhost:7113/cart", {
          method: "POST",
          body: JSON.stringify({
            UserId:user.id,
            ItemId:product.item.id,
            Quantity:newQuantity
          }),
          headers: {
            "Content-type": "application/json; charset=UTF-8",
            "Access-Control-Allow-Origin": "*",
          }
        })
      }
      product.quantity = newQuantity;
    }
  }
})