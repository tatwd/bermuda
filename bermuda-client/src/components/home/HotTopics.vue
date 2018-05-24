<template>
  <div id="hot-topics">
    <v-layout class="hot-topics__slider pt-4 pb-5 px-1" row>
      <v-flex
        v-for="topic in topics"
        :key="topic.id"
        class="mr-3"
      >
        <v-card width="160px">
          <v-card-media
            class="white--text"
            height="220px"
            :src="topic.img_url"
          >
            <v-container fill-height fluid>
              <v-layout fill-height>
                <v-flex x12 align-end flexbox>
                  <span class="headline">{{ topic.name }}</span>
                </v-flex>
              </v-layout>
            </v-container>
          </v-card-media>
        </v-card>
      </v-flex>
    </v-layout>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
import cardSlider from '@/assets/js/card-slider'

export default {
  name: 'HotTopics',
  computed:  mapGetters({
    topics: 'hotTopics'
  }),
  created () {
    // get hot topics
    this.getHotTopics()
  },
  mounted () {
    // start sliding
    this.slideTopicCards()
  },
  methods: {
    slideTopicCards () {
      cardSlider({
        element: document.querySelector('#hot-topics .hot-topics__slider'),
        duration: .5,
        trans: { x:  176},
        interval: 3000,
        timing: 'ease-in-out'
      })
    },

    getHotTopics () {
      this.$store.dispatch('getHotTopics', { count: 10 })
    }
  }
}
</script>

<style scoped>
#hot-topics {
  overflow-x: hidden;
}
</style>
