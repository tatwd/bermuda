import authHelper from '@/assets/js/auth-helper'
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
        let signinUser = JSON.parse(res.data.user)

        if(signinUser.avatar_url)
          signinUser.avatar_url += URL.ROOT

        // save token to localStorage
        authHelper.saveToken({
          access_token: res.data.access_token,
          token_type: res.data.token_type,
          expires_in: res.data.expires_in,
          login_at: res.data.login_at,
          current_user: signinUser
        })

        commit('setUser', signinUser)

        // redirect to home
        payload.redirect();
      })
      .catch(err => {
        console.log(err)
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
