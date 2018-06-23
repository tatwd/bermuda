<template>
  <v-layout row wrap>
    <v-flex
      xs12
      v-for="user in users"
      :key="user.id"
      class="mx-3 mb-3"
    >
      <v-card>
        <v-card-title>
          <router-link :to="goto('UserProfile', user.id)">
            <v-avatar size="56px" color="grey lighten-4">
              <img :src="user.avatar_url | urlFilter" alt="avatar">
            </v-avatar>
          </router-link>
          <h3 class="mx-3">
            <router-link to="/">
              {{ user.name }}
            </router-link>
          </h3>
          <v-subheader>
            关注 {{ user.follower_count }} |
            粉丝 {{ user.following_count }} |
            寻物 {{ user.lost_count }} |
            招领 {{ user.found_count }} |
            助人 {{ user.help_count }}
          </v-subheader>
          <v-spacer></v-spacer>
          <BmdUserFollowBtn
            v-model="user.is_following"
            :uid="user.id"
          />
        </v-card-title>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import BmdUserFollowBtn from '@/components/shared/BmdUserFollowBtn'
import { goto } from '@/utils/link'

export default {
  props: {
    users: {
      type: Array,
      default: null
    }
  },
  components: {
    BmdUserFollowBtn
  },
  methods: {
    goto
  }
}
</script>
