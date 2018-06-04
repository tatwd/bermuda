'use strict'
const merge = require('webpack-merge')
const prodEnv = require('./prod.env')
const { DEV_URL } = require('./url')

module.exports = merge(prodEnv, {
  NODE_ENV: '"development"',
  URL: DEV_URL
})
