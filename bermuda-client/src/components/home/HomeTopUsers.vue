<template>
  <div
    id="top-users"
    class="my-4"
  >
    <v-card>
      <v-card-title>
        <v-icon color="primary">assessment</v-icon>
        <span class="ml-2">{{ title }}</span>
      </v-card-title>
      <v-card-text v-if="topUsers.length">
        <v-list>
          <v-list-tile
            v-for="user in topUsers"
            :key="user.id"
            avatar
          >
            <router-link :to="goto('UserProfile', user.id)">
              <v-list-tile-avatar>
                <img :src="user.avatar_url | urlFilter" :alt="user.name">
              </v-list-tile-avatar>
            </router-link>
            <v-list-tile-content>
              <v-list-tile-title>
                <router-link class="mr-3 hiddem-xs--only" :to="goto('UserProfile', user.id)">{{ user.name }}</router-link>
                <span class="grey--text caption">助人 {{ user.help_count }}</span>
              </v-list-tile-title>
            </v-list-tile-content>
            <v-list-tile-action>
              <BmdUserFollowBtn
                v-model="user.is_following"
                :uid="user.id"
              />
            </v-list-tile-action>
          </v-list-tile>
        </v-list>
      </v-card-text>
    </v-card>
  </div>
</template>

<script>
import { userService } from '@/services'
import BmdUserFollowBtn from '@/components/shared/BmdUserFollowBtn'
import { goto } from '@/utils/link'

export default {
  components: {
    BmdUserFollowBtn
  },
  data: () => ({
    title: '百慕达人',
    topUsers: []
  }),
  created () {
    userService
      .getTop(10)
      .then(res => {
        this.topUsers = res.data
      })
      .catch(console.error)
  },
  methods: { goto }
}
</script>
