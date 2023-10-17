<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name:'ErrorView'
})
</script>

<script setup>
import { useRouter, useRoute } from 'vue-router';

const router = useRouter();
const route = useRoute();

let response = route.params.response;

const returnToCatalog = () =>{
    router.push({name:'Catalog'})
}
</script>

<template>
    <h1 v-if="response === '401'">Unauthorized</h1>
    <h1 v-else-if="type === '403'">Forbidden </h1>
    <button @click="returnToCatalog()">Back to catalog</button>
</template>