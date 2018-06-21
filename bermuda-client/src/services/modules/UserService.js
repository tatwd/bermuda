import userAuth from '@/utils/user-auth'

/**
 * User Service
 */
export default class UserService {
  axios
  baseUrl

  constructor(axios, apiUrl) {
    this.axios = axios
    this.baseUrl = apiUrl
  }

  // signup
  signup (user) {
    let self = this
    return self.axios.post(`${self.baseUrl}/account/register`, user)
  }

  // signin
  signin (user) {
    let self = this
    let data = `username=${user.username}&password=${user.password}&grant_type=password`
    let headers = {
      'Content-Type': 'application/x-www-form-urlencoded',
      'No-Auth':'True'
    }
    return self.axios.post(`${self.baseUrl}/token`, data, { headers })
  }

  // signout
  signout (cb) {
    userAuth.removeToken()
    cb()
  }

  getById (id) {
    let self = this
    return self.axios.get(`${self.baseUrl}/user/${id}`)
  }

  getTop (count) {
    let self = this
    return self.axios.get(`${self.baseUrl}/users/top/${count}`)
  }

  // follow user
  followUser (uid) {
    let self = this
    return self.axios.post(`${self.baseUrl}/user/following/${uid}`)
  }

  // unfollow user
  unfollowUser (uid) {
    let self = this
    return self.axios.delete(`${self.baseUrl}/user/following/${uid}`)
  }

}
