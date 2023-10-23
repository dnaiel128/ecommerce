<script>
import { defineComponent } from 'vue';
import CatalogItem from '../components/CatalogItem.vue';

export default defineComponent({
    name:'CatalogView',
    components:{
        CatalogItem
    }
})
</script>

<script setup>
import { onMounted,ref } from 'vue';
import { useRouter, useRoute } from 'vue-router';

const router = useRouter()
const route = useRoute()

const goToProductPage = (id) => {
    router.push({name:'ProductView', params: {id}})
}

let products = ref([]);

const fetchProductsFromDB = async () => {
    let fetchProducts=[]
    let searchTerm = route.query.name;
    if(!searchTerm) { searchTerm=''; }
      await fetch('https://localhost:7113/product/search?name='+searchTerm)
      .then(res => res.json())
      .then(json => {
        fetchProducts = json;
      })
      return fetchProducts;
    }

onMounted( async () => {
    products.value = await fetchProductsFromDB()
})
</script>

<template>
    <div class="products-list"> 
        <catalog-item class="product-item"
        :product-data="product"
        v-for="product in products"
        :key="product.id"
        @click="goToProductPage(product.id)"
        />
        </div>
</template>

<style scoped>
.products-list{
    display:flex;
    justify-content: space-between;
    flex-wrap: wrap;
}

.product-item{
    flex-basis:28%;
    margin:8px;
    padding:16px;
    box-shadow: 0px 0px 14px 1px #e6d6e6;
    cursor:pointer;
}

.product-item img{
    width:70%;
}
</style>