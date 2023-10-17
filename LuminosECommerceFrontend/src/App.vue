<script setup>
import { useRouter } from 'vue-router';
import {productsStore} from '@/stores/products'
import {computed} from 'vue'
import { authStore } from '@/stores/auth.store.js';

const router=useRouter();
const store = productsStore();
const userStore = authStore();

const baseUrl = `${import.meta.env.VITE_API_URL}`;

const isLogged = computed(() => {
  return localStorage.getItem('user')==null;
})

const logout = () => {
  userStore.logout();
}
</script>

<template>
  <header>
    <div class="cart-items" @click="router.push({name: 'CartView'})">
      <p>Items in Cart: {{ store.cart.length }}</p>
    </div>
    <div class="admin-class" @click="router.push({name: 'AdminView'})">
      <p>Admin</p>
      <p>{{ baseUrl }}</p>
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
