<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name:'CartView'
})
</script>

<script setup>
import { productsStore } from '../stores/products';
import { useRouter } from 'vue-router';

const store = productsStore();
const router = useRouter();

const removeFromCart = (id) => {
    store.removeFromCart(id)
}

const placeOrder = (storeCart) => {
    store.addNewOrder(storeCart)
    addOrder(storeCart)
    store.emptyCart()
    console.log("orderComplete")
    router.push({name:'OrderView'})
}

const addOrder = (storeCart) => {
    let sum = 0
    storeCart.forEach(item => {
        sum +=item.price})
    let OrderedItemsRemake = storeCart.map((item)=> (Number)(item.id))
    console.log("store cart is:"+storeCart)
    console.log(JSON.stringify({
            Total: sum,
            UserId: 1,
            OrderDate: new Date().toJSON(),
            ItemsIds: OrderedItemsRemake}))
    fetch("https://localhost:7113/order/addOrder", {
        method: "POST",
        body: JSON.stringify({
            Total: sum,
            UserId: 1,
            OrderDate: new Date().toJSON(),
            ItemsIds: OrderedItemsRemake
    }),
        headers: {
    "Content-type": "application/json; charset=UTF-8",
    "Access-Control-Allow-Origin": "*"
  }
});
}
</script>

<template>
    <button @click="router.push({name:'Catalog'})">Back to Catalog</button>
    <div v-if="!store.cart.length" style="text-align: center;">
        <h1>Empty Cart...</h1>
    </div>

    <div class="cart-items" v-else>
        <div class="cart-item"
        v-for="item in store.cart" :key="item.id"
        >
        <div class="item-details">
            <img :src="item.imageFolderPath">
            <span>Name: {{ item.name }}</span>
            <span>Category: TestCategory</span>
            <span>Price: ${{ item.price }}</span>
            <button @click="removeFromCart(item.id)">Remove</button>
        </div>
        </div>
        <div class="place-order">
            <button @click="placeOrder(store.cart)">Place Order</button>
        </div>
    </div>
</template>

<style scoped>
.item-details{
    display:flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 32px;
    box-shadow: 0px 0px 17px 6px #e7e7e7;
    border-radius: 8px;
    padding: 16px;
}

.item-details img{
    width:20%;
}
</style>