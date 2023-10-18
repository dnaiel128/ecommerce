<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name:'AdminProductView'
})
</script>

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

let router = useRouter()

const user = JSON.parse(localStorage.getItem('user'));

let newProduct = ref({})

const addProduct = async () => {
    console.log("new product to be added to the db is: "+newProduct.value);
    await fetch("https://localhost:7113/product", {
        method: "POST",
        body: JSON.stringify(newProduct.value),
        headers: {
    "Content-type": "application/json; charset=UTF-8",
    "Access-Control-Allow-Origin": "*",
    "Authorization": `Bearer ${user.token}`
    
  }});
  console.log("added new product product");
}
</script>

<template>
    <div>
        <h2>Add new Product</h2>
        <form @submit="addProduct">
            <div class="form-group">
                <label for="name">Product Name</label>
                <input type="text" v-model="newProduct.name" required />
            </div>
            <div class="form-group">
                <label for="description">Description</label>
                <input type="text" v-model="newProduct.description" required />
            </div>
            <div class="form-group">
                <label for="price">Price</label>
                <input type="text" v-model="newProduct.price" required />
            </div>
            <div class="form-group">
                <input type="text" v-model="newProduct.imageFolderPath" />
                <label for="image-folder-path">ImageURL</label>
            </div>
            <button type="submit">Add New Product</button>
        </form>
        <br>
        <button @click="router.push({name:'Catalog'})">Back to Catalog</button>
        <button @click="router.push({name:'AdminView'})">Back to Admin</button>
    </div>
</template>
