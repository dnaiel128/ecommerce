import { createRouter, createWebHistory } from 'vue-router'
import Catalog from '@/views/Catalog.vue'
import ProductDetail from '@/views/ProductDetail.vue'
import Cart from '@/views/Cart.vue'
import Order from '@/views/Order.vue'
import Admin from '@/views/Admin.vue'
import AdminProductDetails from '@/views/AdminDetail.vue'
import Error from '@/views/Error.vue'
import Login from '@/views/Login.vue'
import Register from '@/views/Register.vue'
import { authStore } from '../stores/auth.store'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Catalog',
      component: Catalog
    },
    {
      path:'/product/:id',
      name: 'ProductView',
      component: ProductDetail
    },
    {
      path:'/cart',
      name: 'CartView',
      component: Cart
    },
    {
      path:'/orders',
      name: 'OrderView',
      component:Order
    },
    {
      path:'/admin',
      name: 'AdminView',
      component:Admin
    },
    {
      path:'/admin/:id',
      name: 'AdminProductView',
      component: AdminProductDetails
    },
    {
      path:'/error/:status',
      name: 'ErrorView',
      component: Error
    },
    {
      path:'/user/login',
      name:'LoginView',
      component:Login
    },
    {
      path:'/user/register',
      name:'RegisterView',
      component:Register
    }
  ]
})

export default router

router.beforeEach(async (to) => {
  // redirect to login page if not logged in and trying to access a restricted page
  const publicPages = ['/user/login','/user/register','/error/:status','/cart','/product/:id','/'];
  const authRequired = !publicPages.includes(to.path);
  const auth = authStore();

  if (authRequired && !auth.user) {
      auth.returnUrl = to.fullPath;
      return '/';
  }
});