<template>
  <div class="notice-list">
    <v-card
      v-for="notice in notices"
      :key="notice.id"
      class="mb-3"
    >
      <v-container grid-list-lg>
        <v-layout row wrap align-center>
          <v-flex xs12 md8 order-xs2 order-md1>
            <v-card-title>
              <h2>{{ notice.title }}</h2>
              <v-chip
                small
                :color="notice.type.includes('寻物') ? 'red' : 'green'"
                text-color="white"
              >
                {{ notice.type }}
              </v-chip>
            </v-card-title>
            <v-card-text>
              <p>
                <v-icon color="primary">access_time</v-icon>
                <span>{{ notice.event_time_desc }}</span>
              </p>
              <p>
                <v-icon color="primary">place</v-icon>
                <span>{{ notice.place }}</span>
              </p>
              <p>
                <v-icon color="primary">wrap_text</v-icon>
                <span>{{ notice.detail }}</span>
              </p>
            </v-card-text>
          </v-flex>
          <v-flex xs12 md4 order-xs1 order-md2>
            <v-card-media
              :src="notice.img_url"
              height="138px"
            ></v-card-media>
          </v-flex>
        </v-layout>
        <v-card-actions>
          <router-link to="/">
            <v-avatar size="36px">
              <img src="@/assets/avatar-tmp.svg" alt="author avatar">
            </v-avatar>
            <span class="hidden-sm-and-down">{{ notice.user_name }}</span>
          </router-link>
          <span class="hidden-sm-and-down grey--text">发布于 2018-12-12</span>
          <v-spacer></v-spacer>
          <router-link to="#" class="mx-2">
            <v-icon color="primary" small left>comment</v-icon>
            {{ notice.cmnt_count }}
          </router-link>
          <v-btn color="primary" small>追踪</v-btn>
        </v-card-actions>
      </v-container>
    </v-card>
  </div>
</template>

<script>
export default {
  name: 'BmdNoticeList',
  props: {
    notices: {
      type: Array,
      default: null
    }
  },
  data: () => ({ })
}
</script>

<style scoped>
.notice-list {
  margin: 16px 0;
}

a {
  text-decoration: none;
}
</style>
