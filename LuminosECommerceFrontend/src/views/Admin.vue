<script>
import { defineComponent } from 'vue';
import AdminItem from '../components/AdminItem.vue'

export default defineComponent({
    name:'AdminView',
    components:{
        AdminItem
    }
})
</script>

<script setup>
import { onMounted, ref } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
let products = ref([]);

const fetchProductsFromDB = async () => {
    let fetchProducts=[]
      await fetch('https://localhost:7113/product/getAll')
      .then(res => res.json())
      .then(json => {
        fetchProducts = json.items;
      })
      return fetchProducts;

    }

onMounted( async () => {
    products.value = await fetchProductsFromDB()
})

const goToProductPage = (id) => {
    router.push({name:'AdminProductView', params: {id}})
}
</script>

<template>
    <button class="btn btn-outline-secondary my-2 my-sm-0" @click="router.push({name:'Catalog'})">Back to Catalog</button>
    <button class="btn btn-outline-secondary my-2 my-sm-0" @click="router.push({name:'AdminNewProductView'})">Add Product</button>
    <div class="container-fluid">
    <div class="row" >
        <admin-item v-for="product in products" :key="product.id" :product-data="product" @click="goToProductPage(product.id)"/>
    </div>
    </div>  
</template>

<style scoped>
</style>