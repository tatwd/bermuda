import { URL, noticeSpecieService } from '../services'

// init state
const state = {
  all: []
}

// getters
const getters = {
  allNoticeSpecies: state => state.all,
  hotNoticeSpecies: state => state.all.sort((a, b) => b.notice_count - a.notice_count)
}

// mutations
const mutations = {
  setAllNoticeSpecies (state, species) {
    state.all = species.map(specie => {
      specie.img_url = URL.ROOT + specie.img_url
      return specie
    })
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
