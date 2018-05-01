import Vue from 'vue'
import Router from 'vue-router'

// import Example from '@/components/Example'
import Home from '@/views/home'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    }
  ],
  mode: 'hash'
})
