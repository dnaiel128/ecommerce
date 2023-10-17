import { defineStore } from 'pinia'

export const productsStore = defineStore('products', {
  state: ()=>({
    products:[],
    cart: [],
    orders:[
      {number: Int16Array, total:Float32Array,orderDate:Date,products:[]}]
  }),
  actions:{
    fetchProductsFromDB() {
      fetch('https://localhost:7113/product/getAll')
      .then(res => res.json())
      .then(json => {
        this.products = json.items;
      })
    },

    addToCart(product){
      this.cart.push(product)
    },

    removeFromCart(id) {
      this.cart = this.cart.filter((item) => item.id !== id)

    },

    emptyCart() {
      this.cart = []
    },

    addNewOrder(order){
      this.orders.push(order)
    }
  }
})