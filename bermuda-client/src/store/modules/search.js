import { searchService } from '@/services'

// init state
const state = {
  result: null
}

// getters
const getters = {
  currentResult: state => state.result
}

// mutations
const mutations = {
  setResult (state, result) {
    state.result = result
  }
}

// actions
const actions = {
  getSearchResult ({ commit }, payload) {
    searchService
      .search(payload.query, payload.type)
      .then(res => {
        commit('setResult', res.data)
        payload.bind.call(this, res.data)
      })
      .catch(err => console.log(err))
  },
  updateSearchResult ({ commit }, payload) {
    commit('setResult', payload.result)
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
