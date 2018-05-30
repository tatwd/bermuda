import Axios from 'axios'

// import services
import TopicService from './modules/TopicService'
import NoticeService from './modules/NoticeService'
import NoticeSpecieService from './modules/NoticeSpecieService'
import UserService from './modules/UserService'
import SearchService from './modules/SearchService'
import FileService from './modules/FileService'

// Axois config
Axios.defaults.headers.common.Accept = 'application/json'

export const URL = {
  ROOT: 'http://localhost:53595',
  API: 'http://localhost:53595/api'
}

export const topicService = new TopicService(Axios, URL.API)
export const noticeService = new NoticeService(Axios, URL.API)
export const noticeSpecieService = new NoticeSpecieService(Axios, URL.API)
export const userService = new UserService(Axios, URL.API)
export const searchService = new SearchService(Axios, URL.API)
export const fileService = new FileService(Axios, URL.API)

export default {
  topicService: new TopicService(Axios, URL.API),
  noticeService: new NoticeService(Axios, URL.API),
  noticeSpecieService: new NoticeSpecieService(Axios, URL.API),
  userService: new UserService(Axios, URL.API),
  searchService: new SearchService(Axios, URL.API),
  fileService: new FileService(Axios, URL.API)
}
