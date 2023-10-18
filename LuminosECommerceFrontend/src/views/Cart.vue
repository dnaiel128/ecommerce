<script>
import { defineComponent,computed } from 'vue';

export default defineComponent({
    name:'CartView'
})
</script>

<script setup>
import { cartStore } from '../stores/cart.store';
import { useRouter } from 'vue-router';

const store = cartStore();
const router = useRouter();

const user = JSON.parse(localStorage.getItem('user'));

const isLogged = computed(() => {
  return user==null;
})
const removeFromCart = async (id,logged) => {
    console.log("The user is logged:"+logged);
    await store.removeFromCart(id,logged)
}

const placeOrder = async (storeCart) => {
    if(!isLogged.value)
    {
        await addOrder(storeCart)
        await store.emptyCart(!isLogged.value)
        console.log("orderComplete")
        router.push({name:'OrderView'})
    }
    else
    {
        await store.emptyCart(!isLogged.value)
        router.push({name:'LoginView'})
    }
}

const addOrder = async (cartItems) => {
    let sum = 0
    cartItems.forEach(item => {
        sum +=item.price})
    console.log("Te user id for which to add order is:"+user.id);
    let OrderedItemsRemake = cartItems.map((item)=> (Number)(item.id))
    console.log("store cart is:"+cartItems)
    console.log(JSON.stringify({
            Total: sum,
            UserId: user.id,
            OrderDate: new Date().toJSON(),
            ItemsIds: OrderedItemsRemake}))
    await fetch("https://localhost:7113/order/addOrder", {
        method: "POST",
        body: JSON.stringify({
            Total: sum,
            UserId: user.id,
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
            <img :src="item.imageFolderPath"/>
            <span>Name: {{ item.name }}</span>
            <span>Category: TestCategory</span>
            <span>Price: ${{ item.price }}</span>
            <button @click="removeFromCart(item.id,!isLogged)">Remove</button>
        </div>
        </div>
        <div class="place-order">
            <button @click="placeOrder(store.cart)">Place Order - TODO: STRIPE</button>
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