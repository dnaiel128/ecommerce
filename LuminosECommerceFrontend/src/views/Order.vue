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

const user = JSON.parse(localStorage.getItem('user'));

const fetchOrders = async () => {
    let fetchOrders=[]
    await fetch(`https://localhost:7113/order/getAllOrders?userId=${user.id}`)
        .then(res => res.json())
        .then(json => {
            fetchOrders = json;
        })
    return fetchOrders;
    
}

onMounted( async () => {
    orders.value = await fetchOrders()
    //console.log("The orders got from db are:"+JSON.stringify(orders.value));
})
</script>

<template>
    <button class="btn btn-outline-secondary" @click="router.push({ name: 'Catalog' })">Back to Catalog</button>
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