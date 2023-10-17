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
import { onMounted } from 'vue';
import { productsStore } from '@/stores/products';
import { useRouter } from 'vue-router';

const store = productsStore()
const router = useRouter()

const goToProductPage = (id) => {
    router.push({name:'ProductView', params: {id}})
}

onMounted( async () => {
    await store.fetchProductsFromDB()
    })
</script>

<template>
    <div class="products-list"> 
        <product-item class="product-item"
        :product-data="product"
        v-for="product in store.products"
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