<template>
  <div class="notice-list">
    <v-card
      color="cyan"
      dark
      v-for="notice in notices"
      :key="notice.id"
      class="mb-3"
    >
      <v-container grid-list-lg>
        <v-layout row wrap>
          <v-flex xs3>
            <v-card-media
              src="https://images.pexels.com/photos/877695/pexels-photo-877695.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
              height="128px"
            ></v-card-media>
          </v-flex>
          <v-flex xs9>
            <v-card-title>{{ notice.title }}</v-card-title>
            <v-card-actions>action</v-card-actions>
          </v-flex>
        </v-layout>
      </v-container>
    </v-card>
  </div>
</template>

<script>
export default {
  name: 'NoticeList',
  props: {
    notices: {
      type: Array,
      default: null
    }
  },
  data () {
    return {}
  }
}
</script>

<style scoped>
.notice-list {
  margin: 16px 0;
}
</style>
