import Axios from 'axios'
import router from '@/router'
import userAuth from '@/utils/user-auth'

// import services
import TopicService from './modules/TopicService'
import NoticeService from './modules/NoticeService'
import NoticeSpecieService from './modules/NoticeSpecieService'
import UserService from './modules/UserService'
import ProductService from './modules/ProductService'
import ShoppingCartService from './modules/ShoppingCartService'
import SearchService from './modules/SearchService'
import FileService from './modules/FileService'

// get token from localStorage
let token = userAuth.getToken()

// Axois config
Axios.defaults.headers.common.Accept = 'application/json'

// Axios 拦截器
// 给请求头添加 access_token
Axios.interceptors.request.use(
  config => {
    if (token) {
      config.headers.Authorization = `${token.token_type} ${token.access_token}`
    }
    return config
  },
  err => Promise.reject(err)
)

// 响应状态为 401 时跳转登录页
Axios.interceptors.response.use(
  res => res,
  err => {
    if (err.response) {
      switch (err.response.status) {
        case 401:
          router.replace({
            path: '/account/signin',
            query: {
              redirect: router.fullPath
            }
          })
      }
    }
  }
)

export const URL = {
  ROOT: 'http://localhost:53595',
  API: 'http://localhost:53595/api'
}

export const topicService = new TopicService(Axios, URL.API)
export const noticeService = new NoticeService(Axios, URL.API)
export const noticeSpecieService = new NoticeSpecieService(Axios, URL.API)
export const userService = new UserService(Axios, URL.API)
export const productService = new ProductService(Axios, URL.API)
export const shoppingCartService = new ShoppingCartService(Axios, URL.API)
export const searchService = new SearchService(Axios, URL.API)
export const fileService = new FileService(Axios, URL.API)

export default {
  topicService,
  noticeService,
  noticeSpecieService,
  userService,
  productService,
  shoppingCartService,
  searchService,
  fileService
}
