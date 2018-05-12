import Axios from 'axios'

// import services
import TopicService from '@/services/TopicService'
import NoticeSpecieService from '@/services/NoticeSpecieService'

const API_URL = 'http://localhost:53595/api'

// Axois config
Axios.defaults.headers.common.Accept = 'application/json'

export default {
  topicService: new TopicService(Axios, API_URL),
  noticeSpecieService: new NoticeSpecieService(Axios, API_URL)
}
