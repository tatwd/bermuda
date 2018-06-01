import Vue from 'vue'
import App from './App'
import router from './router'

import Vuetify from 'vuetify'
import '@/assets/css/google-fonts.css'
import 'vuetify/dist/vuetify.min.css'

// Vuex: for services, shared components, etc
import store from './store'

// config theme
const theme = {
  primary: '#c66b6b', //'#3f51b5',
  secondary: '#b0bec5',
  accent: '#8c9eff',
  error: '#b71c1c'
}

Vue.use(Vuetify, { theme })

Vue.config.productionTip = false

// eslint-disable no-new
new Vue({
  el: '#app',
  router,
  store,
  components: { App },
  template: '<App/>'
})
