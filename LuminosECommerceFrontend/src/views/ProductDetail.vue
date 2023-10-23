<script>
import { defineComponent } from 'vue';
import  ProductItem  from '../components/ProductItem.vue'

export default defineComponent({
    name:'ProductDetails',
    components:{
        ProductItem
    }
  }
)
</script>

<script setup>
import { useRouter} from 'vue-router'
import { ref } from 'vue';

let reload = ref(0);

const router = useRouter();

const reloadComponent = ()=>{
    reload.value += 1;
}
</script>

<template>
    <button class="btn btn-outline-secondary" @click="router.push({name:'Catalog'})">Back to Catalog</button>
    <product-item :key="reload"
    @reload-event="reloadComponent"/>
</template>

