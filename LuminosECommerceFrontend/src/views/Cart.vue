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
  return !(user==null);
})

const removeFromCart = async (id,logged) => {
    await store.removeFromCart(id,logged)
}

const placeOrder = async (storeCart) => {
    if(isLogged.value)
    {
        await addOrder(storeCart)
        await store.emptyCart(isLogged.value)
        router.push({name:'OrderView'})
    }
    else
    {
        router.push({name:'LoginView'})
    }
}

const addOrder = async (cartItems) => {
    let sum = 0
    cartItems.forEach(item => {
        sum +=item.item.price*item.quantity})

    let OrderedItemsRemake = cartItems.map((item)=> ({
        ItemId:(Number)(item.item.id),
        ItemQuantity:item.quantity}
        ))

    await fetch("https://localhost:7113/order/addOrder", {
        method: "POST",
        body: JSON.stringify({
            Total: sum,
            UserId: user.id,
            OrderDate: new Date().toJSON(),
            Items: OrderedItemsRemake
    }),
        headers: {
    "Content-type": "application/json; charset=UTF-8",
    "Access-Control-Allow-Origin": "*"
  }
});
}

let updateQuantity= async(id,logged,inc) =>{
    await store.updateQuantity(id,logged,inc);
}
</script>

<template>
    <button class="btn btn-outline-secondary" @click="router.push({name:'Catalog'})">Catalog</button>
    <button v-if="isLogged" class="btn btn-outline-secondary" @click="router.push({name:'OrderView'})">Orders</button>
    <div v-if="!store.cart.length" style="text-align: center;">
        <h1>Empty Cart...</h1>
    </div>

    <div class="cart-items" v-else>
        <div class="cart-item"
        v-for="cartItem in store.cart" 
        :key="cartItem.item.id"
        >
        <div class="item-details">
            <img :src="cartItem.item.imageFolderPath"/>
            <span>Name: {{ cartItem.item.name }}</span>
            <span>Category: TestCategory</span>
            <span>Price: ${{ cartItem.item.price }}</span>
            <div>
                <span @click="()=>updateQuantity(cartItem.item.id,isLogged,false)">-</span>
                <span>Quantity: {{cartItem.quantity}}</span>
                <span @click="()=>updateQuantity(cartItem.item.id,isLogged,true)">+</span>
            </div>
            <button class="btn btn-outline-danger" @click="removeFromCart(cartItem.item.id,isLogged)">Remove</button>
        </div>
        </div>
        <div class="place-order">
            <button class="btn btn-outline-secondary" @click="placeOrder(store.cart)">Place Order - TODO: STRIPE</button>
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