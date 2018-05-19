import services from '../services'

// server assets url
const ASSETSS_URL = 'http://localhost:53595'

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
  }
}

// actions
const actions = {
  createUser ({ commit }, user) {
    services.userService
      .createUser(user)
      .then(res => {
        commit('setInfo', res.data)
      })
      .catch(err => {
        commit('setInfo', { success: false, msg: err })
      })
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
