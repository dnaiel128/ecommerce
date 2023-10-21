<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name:'ProductDetails'
})
</script>

<script setup>
import { ref, onMounted,computed } from 'vue';
import { cartStore } from '@/stores/cart.store';
import {useRoute, useRouter} from 'vue-router'

const store = cartStore()
const router = useRouter()
const route = useRoute()

let product = ref({})
let productQuantity = ref()

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

const addToCart = (logged,productQuantity) => {
    if(rightNumber()) {
        store.addToCart(product.value,logged,productQuantity)
        router.push({name:'CartView'})
    }
}

const user = JSON.parse(localStorage.getItem('user'));

const isLogged = computed(() => {
  return !(user==null);
})

const rightNumber= () =>{
    if(productQuantity.value!=null) {
        if(productQuantity.value>=1 && productQuantity.value<=100){
            return true;
        }
        else{
            return false;
        }
    }
    return true;
}
onMounted( async () => {
    product.value = await fetchProductFromDB()
})
</script>

<template>
    <button class="btn btn-outline-secondary" @click="router.push({name:'Catalog'})">Back to Catalog</button>
    <div class="product container">
        <div class="product-image">
            <img :src="product.imageFolderPath">
        </div>
        <div class="product-details">
            <p>Name: {{ product.name }}</p>
            <p>Description: {{ product.description }}</p>
            <h2>Price: ${{ product.price }}</h2>
            <div>
                <button class="btn btn-outline-secondary my-2 my-sm-0" @click="addToCart(isLogged,productQuantity)">Add to cart</button>
                <input type="number" class="form-control" v-model="productQuantity"/>
                <span v-show="!rightNumber()">Please enter a number between 1-100.</span>
            </div>
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