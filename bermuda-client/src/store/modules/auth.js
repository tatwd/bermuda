import { userService } from '../services'

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
  signup ({ commit }, user) {
    userService
      .signup(user)
      .then(res => {
        commit('setInfo', res.data)
      })
      .catch(err => {
        commit('setInfo', { success: false, msg: err })
      })
  },
  signin ({ commit }, user) {
    userService
      .signin(user)
      .then(res => {
        commit('setUser', JSON.parse(res.data.user))
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
