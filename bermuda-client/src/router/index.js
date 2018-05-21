import Vue from 'vue'
import Router from 'vue-router'
import userAuth from '@/assets/js/user-auth'

// layouts
import DefaultLayout from '@/layouts/default'
import AccountLayout from '@/layouts/account'
import ErrorLayout from '@/layouts/error'

// view components
import Home from '@/views/home'
import SignIn from '@/views/signin'
import SignUp from '@/views/signup'

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

// get current from localStorage
let currentUser = userAuth.auth().currentUser

// Router Guards
router.beforeEach((to, from, next) => {
  // test log
  // console.log(currentUser)

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
