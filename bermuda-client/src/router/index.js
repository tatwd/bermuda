import Vue from 'vue'
import Router from 'vue-router'
import store from '@/store'
import userAuth from '@/assets/js/user-auth'

// layouts
import DefaultLayout from '@/layouts/default'
import AccountLayout from '@/layouts/account'
import ErrorLayout from '@/layouts/error'

// view components
import Home from '@/views/home'
import Shop from '@/views/shop'
import Cart from '@/views/shop/cart'
import Topic from '@/views/topic'
import SignIn from '@/views/user/signin'
import SignUp from '@/views/user/signup'
import Search from '@/views/search'

Vue.use(Router)

const router = new Router({
  routes: [
    {
      path: '/',
      component: DefaultLayout,
      redirect: '/home',
      children: [
        {
          path: 'home',
          name: 'Home',
          component: Home,
          meta: {
            requiresAuth: false
          }
        },
        {
          path: 'topic',
          name: 'Topic',
          component: Topic,
          meta: {
            requiresAuth: false
          }
        },
        {
          path: 'shop',
          name: 'Shop',
          component: Shop,
          meta: {
            requiresAuth: false
          }
        },
        {
          path: 'shop/cart',
          name: 'Cart',
          component: Cart,
          meta: {
            requiresAuth: false
          }
        },
        {
          path: 'search',
          name: 'Search',
          component: Search,
          meta: {
            requiresAuth: false
          }
        }
      ]
    },
    {
      path: '/account',
      component: AccountLayout,
      children: [
        {
          path: 'signin',
          name: 'SignIn',
          component: SignIn,

        },
        {
          path: 'signup',
          name: 'SignUp',
          component: SignUp
        }
      ],
      meta: {
        requiresGuest: true
      }
    },
    {
      // add 404 route
      path: '*',
      component: ErrorLayout
    }
  ],
  mode: 'hash'
})

// Router Guards
router.beforeEach((to, from, next) => {
  // get current from localStorage
  let currentUser = userAuth.auth().currentUser

  // check user state
  store.dispatch('checkUserState')

  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (!currentUser) {
      next({
        path: '/account/signin',
        query: {
          redirect: to.fullPath
        }
      })
    } else {
      next()
    }
  } else if(to.matched.some(record => record.meta.requiresGuest)) {
    if (currentUser) {
      next({
        path: '/home',
        query: {
          redirect: to.fullPath
        }
      })
    } else {
      next()
    }
  } else {
    next()
  }
})

export default router
