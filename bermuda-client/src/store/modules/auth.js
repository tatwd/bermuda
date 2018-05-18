import services from '../services'

// server assets url
const ASSETSS_URL = 'http://localhost:53595'

// init state
const state = {
  user: null,
  msg: ''
}

// getters
const getters = {
  currentUser: state => state.user
}

// mutations
const mutations = {
  setMsg (state, msg) {
    state.msg = msg
  }
}

// actions
const actions = {
  createUser ({ commit }, user) {
    services.userService
      .createUser(user)
      .then(res => {
        commit('setMsg', res.data)
      })
      .catch(err => console.error(err))
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
