<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'OrderItem'
})
</script>

<script setup>
import { defineProps } from 'vue';

const props = defineProps({
    order: {
        type: Object,
        required: true
    }
})
</script>

<template>
    <div class="jumbotron container">
        <h1 class="display-4">Order: {{ props.order.id }}</h1>
        <hr class="my-4">
        <div v-for="item in props.order.orderedItems" :key="item.id">
            <p>{{ item.item.name }} - ${{ item.item.price }}</p>
        </div>
        <p>Date: {{ props.order.orderDate }}</p>
        <p class="text-right">Total: {{ props.order.total }}$</p>
    </div>
</template>