<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'AdminProductView'
})
</script>

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

let router = useRouter()

const user = JSON.parse(localStorage.getItem('user'));

let newProduct = ref({})

const addProduct = async () => {
    await fetch("https://localhost:7113/product", {
        method: "POST",
        body: JSON.stringify(newProduct.value),
        headers: {
            "Content-type": "application/json; charset=UTF-8",
            "Access-Control-Allow-Origin": "*",
            "Authorization": `Bearer ${user.token}`

        }
    });
}
</script>

<template>
    <div class="container">
        <h2>Add new Product</h2>
        <form @submit="addProduct">
            <div class="form-group">
                <label for="name">Product Name</label>
                <input type="text" class="form-control" v-model="newProduct.name" required>
            </div>
            <div class="form-group">
                <label for="description">Description</label>
                <input type="text" class="form-control" v-model="newProduct.description" required>
            </div>
            <div class="form-group">
                <label for="price">Price</label>
                <input type="text" class="form-control" v-model="newProduct.price" required>
            </div>
            <div class="form-group">
                <label for="image">ImageURL</label>
                <input type="text" class="form-control" v-model="newProduct.imageFolderPath" required>
            </div>

            <button class="btn btn-outline-success" type="submit">Add New Product</button>
        </form>
        <br>
        <button class="btn btn-outline-secondary" @click="router.push({ name: 'Catalog' })">Back to Catalog</button>
        <button class="btn btn-outline-secondary" @click="router.push({ name: 'AdminView' })">Back to Admin</button>
    </div>
</template>
