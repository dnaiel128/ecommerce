<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name:'LoginView'
})
</script>

<script setup>
import { authStore } from '@/stores/auth.store.js';
import {cartStore} from '@/stores/cart.store.js';
import {ref} from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter()

let user = ref({})

const login = async () => {
    const store = authStore();
    const cart = cartStore();
    
    await store.login(user.value.username, user.value.password)

    if(cart.cart.length)
    {
        await cart.addBulk()
    }
    router.push({name:'HomeView'});
}
</script>

<template>
    <div class="container">
        <h2>Login</h2>
        <div class="login">
            <form @submit.prevent="login">
                <div class="form-group">
                    <label for="username">Username</label>
                    <input type="text" class="form-control" v-model="user.username" required />
                </div>
                <div class="form-group">
                    <label for="password">Password</label>
                    <input type="password" class="form-control" v-model="user.password" required />
                </div>
                <button class="btn btn-outline-success" type="submit">Login</button>
            </form>
        </div>
        <br>
        <button class="btn btn-outline-secondary" @click="router.push({name:'Catalog'})">Back to Catalog</button>
    </div>
</template>
