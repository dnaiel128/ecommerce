<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'AdminItem'
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
    <div class="col-sm">
        <img :src="props.productData.imageFolderPath">
        <h2>Name: {{ props.productData.name }}</h2>
    </div>
</template>