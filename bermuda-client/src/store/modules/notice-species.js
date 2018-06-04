import { noticeSpecieService } from '@/services'

// init state
const state = {
  all: []
}

// getters
const getters = {
  allNoticeSpecies: state => state.all
}

// mutations
const mutations = {
  setAllNoticeSpecies (state, species) {
    state.all = species
  }
}

// actions
const actions = {
  getAllNoticeSpecies ({ state, commit }) {
    noticeSpecieService
      .getAll()
      .then(res => {
        commit('setAllNoticeSpecies', res.data)
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
