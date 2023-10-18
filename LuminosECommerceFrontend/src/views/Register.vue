<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name:'RegisterView'
})
</script>

<script setup>
import { authStore } from '@/stores/auth.store.js';
import {ref} from 'vue';
import { useRouter } from 'vue-router';

let router = useRouter()

let user = ref({})

const registerUser = () => {
    const store = authStore();
    return store.register(user.value.username, user.value.password, user.value.firstName,
    user.value.lastName, user.value.isAdmin)
}
</script>

<template>
    <div class="container">
        <div class="row justify-content-center">
    <div class="col-4">
        <h2>Register</h2>
        <form @submit.prevent="registerUser">
            <div class="form-group">
                <label for="username">Username</label>
                <input type="text" class="form-control" v-model="user.username" required />
            </div>
            <div class="form-group">
                <label for="password">Password</label>
                <input type="password" class="form-control" v-model="user.password" required />
            </div>
            <div class="form-group">
                <label for="first-name">First Name</label>
                <input type="text" class="form-control" v-model="user.firstName" required />
            </div>
            <div class="form-group">
                <label for="last-name">First Name</label>
                <input type="text" class="form-control" v-model="user.lastName" required />
            </div>
            <div class="form-group">
                <input type="checkbox" class="form-check-input" v-model="user.isAdmin" />
                <label for="isAdmin">Is Admin</label>
            </div>
            <button class="btn btn-outline-success" type="submit">Register</button>
        </form>
        <br>
        <button class="btn btn-outline-secondary" @click="router.push({name:'Catalog'})">Back to Catalog</button>
    </div>
    </div>
    </div>
</template>
