<script>
import { defineComponent } from 'vue';
import OrderItem from '../components/OrderItem.vue';

export default defineComponent({
    name: 'OrderView',
    components:{
        OrderItem
    }
})
</script>

<script setup>
import { useRouter } from 'vue-router';
import { onMounted, ref} from 'vue';

const router = useRouter();
let orders = ref([]);

const fetchOrders = async () => {
    let fetchOrders=[]
    await fetch('https://localhost:7113/order/getAllOrders')
        .then(res => res.json())
        .then(json => {
            console.log(json);
            fetchOrders = json;
        })
    return fetchOrders;
    
}

onMounted( async () => {
    orders.value = await fetchOrders()
})
</script>

<template>
    <button @click="router.push({ name: 'Catalog' })">Back to Catalog</button>
    <div v-if="!orders.length" style="text-align: center;">
        <h1>No orders...</h1>
    </div>

    <div class="orders" v-else>
        <div class="order-item" v-for="item in orders" :key="item.id">
            <order-item :order="item"/>
        </div>
    </div>
</template>

<style scoped></style>