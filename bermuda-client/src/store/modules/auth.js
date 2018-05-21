// import authHelper from '@/assets/js/auth-helper'
import userAuth from '@/assets/js/user-auth'
import { URL, userService } from '../services'

// init state
const state = {
  user: null,
  info: null
}

// getters
const getters = {
  currentUser: state => {
    // 判断 access_token 是否过期
    return !authHelper.expired() ? state.user : null
  },
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
        payload.redirect();
      })
      .catch(err => {
        commit('setInfo', { success: false, msg: err })
      })
  },
  signin ({ commit }, payload) {
    userService
      .signin(payload.user)
      .then(res => {
        let _currentUser = JSON.parse(res.data.current_user)

        if(_currentUser.avatar_url)
          _currentUser.avatar_url += URL.ROOT

        res.data.current_user = _currentUser
        userAuth.updateToken(res.data);

        commit('setUser', _currentUser)

        // redirect to home
        payload.redirect();
      })
      .catch(err => {
        commit('setInfo', { success: false, msg: '用户名或密码错误' })
      })
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
