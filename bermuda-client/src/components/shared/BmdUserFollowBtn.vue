<template>
  <v-btn
    v-if="!isFollowing"
    color="green"
    dark
    small
    @click="followUser"
  >
    <v-icon left>add</v-icon>
    关注
  </v-btn>
  <v-btn
    v-else
    color="grey"
    dark
    small
    @click="unfollowUser"
  >
    取消关注
  </v-btn>
</template>

<script>
import { userService } from '@/services'

export default {
  model: {
    prop: 'isFollowing',
    event: 'click'
  },
  props: {
    isFollowing: {
      type: Boolean,
      default: () => false
    },
    uid: {
      type: Number,
      default: null
    }
  },
  methods: {
    followUser () {
      userService
        .followUser(this.uid)
        .then(res => {
          if (res.data.success) {
            this.$emit('click', true)
          }
        })
        .catch(console.error)
    },

    unfollowUser () {
      userService
        .unfollowUser(this.uid)
        .then(res => {
          if (res.data.success) {
            this.$emit('click', false)
          }
        })
        .catch(console.error)
    }
  }
}
</script>

