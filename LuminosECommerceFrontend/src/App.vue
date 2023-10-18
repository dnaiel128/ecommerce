<script setup>
import { useRouter } from 'vue-router';
import {cartStore} from '@/stores/cart.store'
import {computed,watch,ref,onMounted} from 'vue'
import { authStore } from '@/stores/auth.store.js';


const router = useRouter();
const store = cartStore();
const userStore = authStore();

const user = JSON.parse(localStorage.getItem('user'));

watch(router, async () => {
  isLogged()
})

const isLogged = computed(() => {
  return user==null;
})

let cart = ref([])

const getCart = async () => {
    let cart = {}
    if(!isLogged.value){
      await fetch("https://localhost:7113/cart/getAllCartProducts?userId="+user.id, {
        method: "GET",
        headers: {
          "Content-type": "application/json; charset=UTF-8",
          "Access-Control-Allow-Origin": "*"
        }
      })
      .then(res => res.json())
      .then(json => {
        cart = json;
        /*console.log("The cart for the user from db is:"+cart);
        console.log("The json receivedd is:"+JSON.stringify(json));*/
      })
    }
    if(cart==undefined) { return [];}
    else { return cart;}
}

const logout = () => {
  userStore.logout();
  location.reload();
}

onMounted(async()=>{
  /*const cart = (localStorage.getItem('cart'));
  console.log("The persisted cart in the local store is:"+cart);*/

  if(!isLogged.value)
  {
    //console.log("we are logged");
    cart.value = await getCart()
    /*console.log("The value of the received cart is:"+cart.value);
    console.log("The before cart value is:"+store.cart);*/
    store.cart = cart.value
  }
  else
  {
    console.log("we are not logged");
    store.cart = [];
  }  
})

/* nu aici fac asta, cand se adauga un produs la cos, automat adaug si eu in local storage extra item, sau scot
onUnmounted(() => {
  console.log("The following cart is persited before exit:"+store.cart);
  localStorage.setItem('cart', store.cart);
})*/
</script>

<template>
  <header>
    <div class="cart-items" @click="router.push({name: 'CartView'})">
      <p>Items in Cart: {{ store.cart.length }}</p>
    </div>
    <div class="admin-class" @click="router.push({name: 'AdminView'})">
      <p v-if="!(user==null) && user.isAdmin">Admin</p>
    </div>
    <div class="user">
      <div class="user-login" v-if="isLogged">
        <p class="user-button" @click="router.push({name:'LoginView'})">Login</p>
        <p class="user-button" @click="router.push({name:'RegisterView'})">Register</p>
      </div>
      <div class="user-logout" v-else>
        <p class="user-button" @click="logout()">Logout</p>
      </div>
    </div>
  </header>
  <main>
    <RouterView />
  </main>
</template>

<style scoped>
.cart-items{
  text-align:end;
  padding:16px;
  font-weight: bold;
  font-size:24px;
  cursor: pointer;
}
</style>
