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
import Home from '@/views/Home.vue'
import AdminProduct from '@/views/AdminProduct.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/catalog',
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
      component:Order,
      meta: {
        requiresAuth: true
      }
    },
    {
      path:'/admin',
      name: 'AdminView',
      component:Admin,
      meta: {
        requiresAdmin: true
      }
    },
    {
      path:'/admin/:id',
      name: 'AdminProductView',
      component: AdminProductDetails,
      meta: {
        requiresAdmin: true
      }
    },
    {
      path:'/admin/addProduct',
      name: 'AdminNewProductView',
      component: AdminProduct,
      meta: {
        requiresAdmin: true
      }
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
    },
    {
      path:'/',
      name:'HomeView',
      component:Home
    }
  ]
})

export default router

router.beforeEach(async (to, from, next) => {
  // redirect to login page if not logged in and trying to access a restricted page
  const requiresAdmin = to.meta.requiresAdmin;
  const requireAuth = to.meta.requiresAuth;
  const user = JSON.parse(localStorage.getItem('user'));

  /*
  const publicPages = ['/user/login','/user/register','/error/:status','/cart','/product/:id','/'];
  const authRequired = !publicPages.includes(to.path);

  const auth = authStore();
  if (authRequired && !auth.user) {
      auth.returnUrl = to.fullPath;
      return '/';
  }*/

  if(requiresAdmin)
  {
    if(user && user.isAdmin)
    {
      next();
    }
    else
    {
      next('/');
    }
  }
  else if(requireAuth)
  {
    if(user)
    {
      next();
    }
    else
    {
      next('/');
    }
  }
  else
  {
    next();
  }
});