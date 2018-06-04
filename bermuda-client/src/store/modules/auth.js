import { userService } from '@/services'
import userAuth from '@/utils/user-auth'

// init state
const state = {
  user: null,
  info: null
}

// getters
const getters = {
  currentUser: state => state.user,
  currentInfo: state => state.info
}

// mutations
const mutations = {
  setInfo (state, msg) {
    state.info = msg
  },
  setUser (state, user) {
    state.user = user
  }
}

// actions
const actions = {
  signup ({ commit }, payload) {
    userService
      .signup(payload.user)
      .then(res => {
        commit('setInfo', res.data)

        // redirect to sign in page
        if (res.data.success) {
          payload.redirect();
        }
      })
  },
  signin ({ commit }, payload) {
    userService
      .signin(payload.user)
      .then(res => {
        // save token to localStorage
        userAuth.updateToken(res.data);

        commit('setUser', res.data.current_user)
        commit('setInfo', { success: true, msg: '登录成功' })

        // redirect to home
        payload.redirect();
      })
      .catch(err => {
        commit('setInfo', { success: false, msg: '用户名或密码错误' })
      })
  },
  signout: ({ commit }, payload) => {
    userService
      .signout(() => {
        commit('setUser', null)
        payload.redirect()
      })
  },
  checkUserState ({ commit }) {
    let _currentUser = userAuth.auth().currentUser
    commit('setUser', _currentUser)
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
