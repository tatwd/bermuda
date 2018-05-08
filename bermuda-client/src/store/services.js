import Axios from 'axios'
import TopicService from '@/services/TopicService'

const API_URL = 'http://localhost:53595/api'

// Axois config
Axios.defaults.headers.common.Accept = 'application/json'

export default {
  topicService: new TopicService(Axios, API_URL)
}
