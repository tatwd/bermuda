import Vue from 'vue'
import Router from 'vue-router'

import DefaultLayout from '@/layout/default'

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
      // TODO: add 404 route
      path: '*'
    }
  ],
  mode: 'hash'
})
