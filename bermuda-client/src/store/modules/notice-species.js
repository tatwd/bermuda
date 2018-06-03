import { URL, noticeSpecieService } from '@/services'

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
