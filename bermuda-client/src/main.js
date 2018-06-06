/**
 * Copyright 2017 Bermuda Team.  All rights reserved.
 *
 * The project is our team's learning project during our colloge
 * which based Mircosoft SQL Server, and used ASP.NET WebAPI,
 * Entity Framework, Lucene.Net and Vue.js ecosystem. we have
 * already push the source to GitHub. So it means that you can visit
 * https://github.com/tatwd/bermuda for more details. We have not
 * considered using any license, but we welcome everyone to fix bugs
 * or contribute this project! Please do not use our code in commercial
 * and/or profit-oriented projects whithout premission. Thank you!
 */

import Vue from 'vue'
import App from './App'
import router from './router'

import Vuetify from 'vuetify'
import '@/assets/css/google-fonts.css'
import 'vuetify/dist/vuetify.min.css'

// Vuex: for services, shared components, etc
import store from './store'

// import filters
import { dateFilter, urlFilter } from '@/filters'

Vue.filter('dateFilter', dateFilter)
Vue.filter('urlFilter', urlFilter)

// config theme
const theme = {
  primary: '#c66b6b', // '#3f51b5',
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
