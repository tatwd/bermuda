import Axios from 'axios'
import TopicService from '@/services/TopicService'

const apiUrl = 'http://localhost:56364/api'

// Axois config
Axios.defaults.headers.common.Accept = 'application/json'

export default {
  topicService: null
}
