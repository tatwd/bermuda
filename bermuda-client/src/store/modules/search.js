import { URL, searchService } from '../services'
import imgUrlFilter from '@/filter/img-url'

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
        res.data = res.data && imgUrlFilter(res.data, URL.ROOT)
        commit('setResult', res.data)
        payload.bind.call(this, res.data)
      })
      .catch(err => console.log(err))
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
