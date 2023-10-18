<script>
import { defineComponent } from 'vue';
import ProductItem from '../components/ProductItem.vue';

export default defineComponent({
    name:'CatalogView',
    components:{
        ProductItem
    }
})
</script>

<script setup>
import { onMounted,ref } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter()

const goToProductPage = (id) => {
    router.push({name:'ProductView', params: {id}})
}

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
</script>

<template>
    <div class="products-list"> 
        <product-item class="product-item"
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