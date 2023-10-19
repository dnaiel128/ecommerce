import { defineStore } from 'pinia'

export const cartStore = defineStore('cart', {
  state: ()=>({
    cart: []
  }),

  actions:{
    async addToCart (product,logged) {
      let user = JSON.parse(localStorage.getItem('user'));
      if(logged){
        await fetch("https://localhost:7113/cart", {
          method: "POST",
          body: JSON.stringify({
            UserId:user.id,
            ItemId:product.id
          }),
          headers: {
            "Content-type": "application/json; charset=UTF-8",
            "Access-Control-Allow-Origin": "*",
          }
        })
      }
      this.cart.push(product)
    },

    async removeFromCart(id,logged) {
      let user = JSON.parse(localStorage.getItem('user'));
      let product = this.cart.find((item)=>item.id=id);
      if(logged){
        await fetch("https://localhost:7113/cart", {
          method: "DELETE",
          body: JSON.stringify({
            UserId:user.id,
            ItemId:product.id
          }),
          headers: {
            "Content-type": "application/json; charset=UTF-8",
            "Access-Control-Allow-Origin": "*",
          }
        })
      }
      this.cart = this.cart.filter((item) => item.id !== id)
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
          ItemId:item.id
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
    }
  }
})