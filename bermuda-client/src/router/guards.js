import store from '@/store'
import userAuth from '@/assets/js/user-auth'

export const beforeEachGuard = function (to, from, next) {
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
}

export default {
  beforeEachGuard,
}
