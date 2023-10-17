<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'OrderItem'
})
</script>

<script setup>
import { defineProps } from 'vue';

const props = defineProps({
    order:{
        type: Object,
        required: true
    }
})
</script>

<template>
    <div class="order-item">
        <h2>Order: {{ props.order.id }}</h2>
        <div v-for="item in props.order.orderedItems" :key="item.id">
            <p>{{item.item.name}} - ${{ item.item.price }}</p>
        </div>
        <p>Date: {{ props.order.orderDate }} - Total: {{ props.order.total }}</p>
    </div>
</template>