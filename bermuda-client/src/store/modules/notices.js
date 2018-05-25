import { URL, noticeService } from '../services'
import imgUrlFilter from '@/filter/img-url'

// init state
const state = {
  all: null
}

// getters
const getters = {
  allNotices: state => state.all
}

// mutations
const mutations = {
  setAllNotices (state, notices) {
    state.all = notices
  }
}

// actions
const actions = {
  getAllNotices ({ commit }) {
    noticeService
      .getAll()
      .then(res => {
        res.data = imgUrlFilter(res.data, URL.ROOT)
        commit('setAllNotices', res.data)
      })
      .catch(err => console.log('getAllNotices => ', err))
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
