import { URL, noticeService } from '@/services'
import imgUrlFilter from '@/filter/img-url'

// init state
const state = {
  all: null
}

// getters
const getters = {
  allNotices: state => state.all,
  allLostNotices: state => (
    state.all && state.all.filter(notice => notice.type.includes('寻物'))
  ),
  allFoundNotices: state => (
    state.all && state.all.filter(notice => notice.type.includes('招领'))
  )
}

// mutations
const mutations = {
  setAllNotices (state, { notices }) {
    state.all = notices
  }
}

// actions
const actions = {
  getAllNotices ({ commit }, payload) {
    noticeService
      .getAll()
      .then(res => {
        const notices = imgUrlFilter(res.data, URL.ROOT)
        commit('setAllNotices', { notices })
        payload.bind()
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
