import Vue from 'vue'
import Router from 'vue-router'

// layouts
import DefaultLayout from '@/layouts/default'
import ErrorLayout from '@/layouts/error'

// view components
// import Example from '@/components/Example'
import Home from '@/views/home'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      component: DefaultLayout,
      redirect: '/home',
      children: [
        {
          path: 'home',
          name: 'Home',
          component: Home
        }
      ]
    },
    {
      // TODO: add account routes
      path: '/account/',
    },
    {
      // add 404 route
      path: '*',
      component: ErrorLayout
    }
  ],
  mode: 'hash'
})
