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
    <h1>Home Page</h1>
    <h3>Inser Carousell and/or Item Categories</h3>
    <button @click="router.push({name:'Catalog'})">Catalog</button>
</template>