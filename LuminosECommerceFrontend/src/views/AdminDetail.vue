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

const user = JSON.parse(localStorage.getItem('user'));

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
    "Access-Control-Allow-Origin": "*",
    "Authorization": `Bearer ${user.token}`
    
  }});
  console.log("updated product");
}

const deleteProductFromDB = async() => {
    let id = Number(route.params.id);
    await fetch("https://localhost:7113/product?itemId="+id, {
        method: "DELETE",
        headers: {
    "Content-type": "application/json; charset=UTF-8",
    "Access-Control-Allow-Origin": "*",
    "Authorization": `Bearer ${user.token}`
    
  }});
  console.log("deleted product");
  router.push({name:'AdminView'});
}
onMounted( async () => {
    product.value = await fetchProductFromDB()
})
</script>

<template>
    <button @click="router.push({name:'Catalog'})">Back to Catalog</button>
    <button @click="router.push({name:'AdminView'})">Back to Admin</button>
    <div class="admin-product">
        <div class="product-image">
            <img :src="product.imageFolderPath">
        </div>
        <div class="product-details">
            <form @submit="updatedProductToDB()">
                <div class="form-group">
                    <label for="name">Product Name</label>
                    <input type="text" v-model="product.name"/>
                </div>
                <div class="form-group">
                    <label for="description">Description</label>
                    <input type="text" v-model="product.description"/>
                </div>
                <div class="form-group">
                    <label for="price">Price</label>
                    <input type="text" v-model="product.price"/>
                </div>
                <div class="form-group">
                    <label for="image">ImageURL</label>
                    <input type="text" v-model="product.imageFolderPath"/>
                </div>
                <button type="submit">Update</button>
            </form>
            <button @click="deleteProductFromDB">Delete</button>
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