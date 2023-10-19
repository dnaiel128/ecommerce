<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name:'HomeView'
})
</script>

<script setup>
import { useRouter } from 'vue-router';

const router = useRouter()
</script>

<template>
    <div class="container">
        <h1>Home Page</h1>
        <h3>Inser Carousell and/or Item Categories</h3>
        <button class="btn btn-outline-secondary my-2 my-sm-0" @click="router.push({name:'Catalog'})">Catalog</button>
    </div>
</template>
