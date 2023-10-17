<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name:'LoginView'
})
</script>

<script setup>
import { authStore } from '@/stores/auth.store.js';
import {ref} from 'vue';

let user = ref({})

const login = () => {
    const store = authStore();
    return store.login(user.value.username, user.value.password)
}
</script>

<template>
    <div>
        <h2>Login</h2>
        <div class="login">
            <form @submit.prevent="login">
                <div class="form-group">
                    <label for="username">Username</label>
                    <input type="text" v-model="user.username" required />
                </div>
                <div class="form-group">
                    <label for="password">Password</label>
                    <input type="password" v-model="user.password" required />
                </div>
                <button type="submit">Login</button>
            </form>
        </div>
    </div>
</template>
