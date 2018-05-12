import services from '../services'

// server assets url
const ASSETSS_URL = 'http://localhost:53595'

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
      specie.img_url = ASSETSS_URL + specie.img_url
      return specie
    })
  }
}

// actions
const actions = {
  getAllNoticeSpecies ({ state, commit }) {
    services.noticeSpecieService
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
