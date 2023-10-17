<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'ProductItem'
})
</script>

<script setup>
import { defineProps } from 'vue';

const props = defineProps({
    productData:{
        type: Object,
        required: true
    }
})
</script>

<template>
    <div class="product-item-component">
        <img :src="props.productData.imageFolderPath">
        <h2>Name: {{ props.productData.name }}</h2>
        <p>Description: {{ props.productData.description }}</p>
        <p>Price: ${{ props.productData.price }}</p>
    </div>
</template>