'use strict'
const merge = require('webpack-merge')
const devEnv = require('./dev.env')
const { TEST_URL } = require('./url')

module.exports = merge(devEnv, {
  NODE_ENV: '"testing"',
  URL: TEST_URL
})
