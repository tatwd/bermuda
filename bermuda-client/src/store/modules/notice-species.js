import services from '../services'

// server assets url
const ASSETSS_URL = 'http://localhost:53595'

// init state
const state = {
  all: [],
  isLoaded: false
}

// getters
const getters = {
  allNoticeSpecies: state => state.all,
  hotNoticeSpecies: state => state.all.sort((a, b) => b.notice_count - a.notice_count),
  testGetDate: () => Date.now()
}

// mutations
const mutations = {
  setAllNoticeSpecies (state, species) {
    state.all = species.map(specie => {
      specie.img_url = ASSETSS_URL + specie.img_url
      return specie
    })

    state.isLoaded = true
  }
}

// actions
const actions = {
  getAllNoticeSpecies ({ state, commit }) {
    if (!state.isLoaded) {
      services.noticeSpecieService
      .getAll()
      .then(res => {
        commit('setAllNoticeSpecies', res.data)
      })
      .catch(err => console.error(err))
    }
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
