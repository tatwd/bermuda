import Vue from 'vue'
import Router from 'vue-router'
import routes from './routes'
import { beforeEachGuard } from './guards'

Vue.use(Router)

const router = new Router({
  routes,
  mode: 'hash'
})

// Router Guards
router.beforeEach(beforeEachGuard)

export default router
