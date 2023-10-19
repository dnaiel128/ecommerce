<script setup>
import { useRouter } from 'vue-router';
import { cartStore } from '@/stores/cart.store'
import { computed, watch, ref, onMounted } from 'vue'
import { authStore } from '@/stores/auth.store.js';


const router = useRouter();
const store = cartStore();
const userStore = authStore();

let user = JSON.parse(localStorage.getItem('user'));

watch(() => router.currentRoute.value, (to, from) => {

  if(from.fullPath=='/user/login' && to.fullPath=='/'){
    location.reload();
  }
})

const isLogged = computed(() => {
  return !(user == null);
})

let cart = ref([])

const getCart = async () => {
  let cart = {}
  if (isLogged.value) {
    await fetch("https://localhost:7113/cart/getAllCartProducts?userId=" + user.id, {
      method: "GET",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
        "Access-Control-Allow-Origin": "*"
      }
    })
      .then(res => res.json())
      .then(json => {
        cart = json;
      })
  }
  if (cart == undefined) { return []; }
  else { return cart; }
}

const logout = () => {
  userStore.logout();
  location.reload();
}

onMounted(async () => {

  if (isLogged.value) {
    cart.value = await getCart()
    store.cart = cart.value
  }
  else {
    store.cart = [];
  }
})

</script>

<template>
  <header>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" @click="router.push({name:'HomeView'})" style="cursor: pointer">Store</a>
      <button class="navbar-toggler"  type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item active">
            <a class="nav-link" @click="router.push({name:'HomeView'})" style="cursor: pointer">Home <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item active">
            <a class="nav-link" @click="router.push({name:'Catalog'})" style="cursor: pointer">Catalog <span class="sr-only">(current)</span></a>
          </li>
        </ul>
        <form class="form-inline my-2 my-lg-0 mr-auto">
          <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
          <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
        </form>
        <ul class="navbar-nav mr-auto">
          <li class="nav-item active">
            <a class="nav-link" @click="router.push({ name: 'CartView' })" style="cursor: pointer">Cart({{ store.cart.length }}) <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item active" v-if="!(user == null) && user.isAdmin">
            <a class="nav-link" @click="router.push({ name: 'AdminView' })" style="cursor: pointer">Admin <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item active" v-if="!isLogged">
            <a class="nav-link" @click="router.push({ name: 'LoginView' })" style="cursor: pointer">Login <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item active" v-if="!isLogged">
            <a class="nav-link" @click="router.push({ name: 'RegisterView' })" style="cursor: pointer">Register <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item active" v-if="isLogged">
            <a class="nav-link" @click="logout()" style="cursor: pointer">Logout <span class="sr-only">(current)</span></a>
          </li>
        </ul>
      </div>
    </nav>
  </header>
  <main>
    <RouterView />
  </main>
</template>

<style scoped>
.cart-items {
  text-align: end;
  padding: 16px;
  font-weight: bold;
  font-size: 24px;
  cursor: pointer;
}
</style>
