import Axios from 'axios'
import router from '@/router'
import userAuth from '@/utils/user-auth'

// import services
import TopicService from './modules/TopicService'
import NoticeService from './modules/NoticeService'
import NoticeSpecieService from './modules/NoticeSpecieService'
import CurrentService from './modules/CurrentService'
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

const API_URL = `${process.env.URL}api`

export const topicService = new TopicService(Axios, API_URL)
export const noticeService = new NoticeService(Axios, API_URL)
export const noticeSpecieService = new NoticeSpecieService(Axios, API_URL)
export const currentService = new CurrentService(Axios, API_URL)
export const userService = new UserService(Axios, API_URL)
export const productService = new ProductService(Axios, API_URL)
export const shoppingCartService = new ShoppingCartService(Axios, API_URL)
export const searchService = new SearchService(Axios, API_URL)
export const fileService = new FileService(Axios, API_URL)
