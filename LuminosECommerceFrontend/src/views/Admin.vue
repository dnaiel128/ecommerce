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
    <button>Add Product</button>
    <div class="admin-item-list" v-for="product in products" :key="product.id">
        <admin-item :product-data="product" @click="goToProductPage(product.id)"/>
    </div>
</template>

<style scoped>
</style>