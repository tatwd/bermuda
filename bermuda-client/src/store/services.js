import Axios from 'axios'

// import services
import TopicService from '@/services/TopicService'
import NoticeSpecieService from '@/services/NoticeSpecieService'
import UserService from '@/services/UserService'

// Axois config
Axios.defaults.headers.common.Accept = 'application/json'

export const URL = {
  ROOT: 'http://localhost:53595',
  API: 'http://localhost:53595/api'
}

export const topicService = new TopicService(Axios, URL.API)
export const noticeSpecieService = new NoticeSpecieService(Axios, URL.API)
export const userService = new UserService(Axios, URL.API)

export default {
  topicService: new TopicService(Axios, URL.API),
  noticeSpecieService: new NoticeSpecieService(Axios, URL.API),
  userService: new UserService(Axios, URL.API)
}
