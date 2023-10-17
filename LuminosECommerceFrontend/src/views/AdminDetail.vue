<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name:'AdminProductDetails'
})
</script>

<script setup>
import {ref, onMounted} from 'vue';
import { useRoute, useRouter } from 'vue-router';

const router = useRouter();
const route = useRoute();
let product = ref({})

const fetchProductFromDB = async () => {
    let fetchProduct={}
    let id = Number(route.params.id);
      await fetch('https://localhost:7113/product?id='+id)
      .then(res => res.json())
      .then(json => {
        fetchProduct = json;
      })
      return fetchProduct;
    }

const updatedProductToDB = async () => {
    console.log(product.value)
    await fetch("https://localhost:7113/product", {
        method: "PUT",
        body: JSON.stringify(product.value),
        headers: {
    "Content-type": "application/json; charset=UTF-8",
    "Access-Control-Allow-Origin": "*"
  }});
  location.reload();
}

onMounted( async () => {
    product.value = await fetchProductFromDB()
})
</script>

<template>
    <button @click="router.push({name:'AdminView'})">Back to Admin</button>
    <div class="admin-product">
        <div class="product-image">
            <img :src="product.imageFolderPath">
        </div>
        <div class="product-details">
            <p>Name: {{ product.name }}</p>
            <p>Description: {{ product.description }}</p>
            <h2>Price: ${{ product.price }}</h2>
            <input v-model="product.name" :placeholder="product.name" />
            <button @click="updatedProductToDB()">Update Product</button>
        </div>
    </div>
</template>

<style scoped>
.product{
    display:flex;
    margin-top:50px;
}

.product-image{
    margin-right:24px;
}
</style>