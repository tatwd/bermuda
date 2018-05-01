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
          <v-flex xs12 md8 order-xs2 order-md1>
            <v-card-title>
              {{ notice.title }}
            </v-card-title>
            <v-card-actions>action</v-card-actions>
          </v-flex>
          <v-flex xs12 md4 order-xs1 order-md2>
            <v-card-media
              :src="notice.img"
              height="138px"
            ></v-card-media>
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
