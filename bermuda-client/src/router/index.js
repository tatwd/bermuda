import Vue from 'vue'
import Router from 'vue-router'

// import Example from '@/components/Example'
import HomeIndex from '@/components/Home/Index'
import Index from '@/views/index'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HomeIndex',
      component: HomeIndex
    },
    {
      path: '/index',
      name: 'Index',
      component: Index
    }
  ],
  mode: 'hash'
})
