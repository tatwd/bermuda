import Vue from 'vue'
import Router from 'vue-router'

// import Example from '@/components/Example'
import HomeIndex from '@/components/Home/Index'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HomeIndex',
      component: HomeIndex
    }
  ],
  mode: 'hash'
})
