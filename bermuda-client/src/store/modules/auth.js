import { URL, userService } from '@/services'
import userAuth from '@/utils/user-auth'
import imgUrlFilter from '@/filter/img-url'

// init state
const state = {
  user: null, // userAuth.auth().currentUser,
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
        // filter img url
        let _currentUser = imgUrlFilter(
          JSON.parse(res.data.current_user),
          URL.ROOT
        )
        res.data.current_user = _currentUser

        // save token to localStorage
        userAuth.updateToken(res.data);

        commit('setUser', _currentUser)
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
