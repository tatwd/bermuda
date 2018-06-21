<template>
  <v-layout row wrap>
    <v-flex
      xs12
      v-for="notice in notices"
      :key="notice.id"
      class="mx-3 mb-3"
    >
      <v-card>
        <v-card-title>
          <h2>
            <router-link class="black--text" to="/">
              {{ notice.title }}
            </router-link>
          </h2>
          <v-chip
            small
            :color="typeColor[notice.type]"
            text-color="white"
          >
            {{ notice.type }}
          </v-chip>
        </v-card-title>
        <v-layout row wrap>
          <v-flex xs12 md8 order-xs2 order-md1>
            <v-card-text>
                <p>
                  <v-icon color="primary">access_time</v-icon>
                  <span>{{ notice.event_time_desc }}</span>
                </p>
                <p>
                  <v-icon color="primary">place</v-icon>
                  <span>{{ notice.place }}</span>
                </p>
                <p class="mb-0">
                  <v-icon color="primary">wrap_text</v-icon>
                  <span>{{ notice.detail }}</span>
                </p>
            </v-card-text>
          </v-flex>
          <v-flex xs12 md4 order-xs1 order-md2 class="px-3">
            <v-card-media
              :src="notice.img_url | urlFilter"
              height="138px"
            ></v-card-media>
          </v-flex>
        </v-layout>
        <v-card-actions class="grey--text px-3">
          <span>追踪数：{{ notice.trace_count }}</span>
          <span class="mx-2">评论数：{{ notice.cmnt_count }}</span>
        </v-card-actions>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
  props: {
    notices: {
      type: Array,
      default: null
    }
  },
  data: () => ({
    typeColor: {
      '寻物启事': 'red',
      '招领启事': 'orange'
    }
  })
}
</script>
