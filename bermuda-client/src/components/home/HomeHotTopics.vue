<template>
  <div id="hot-topics" class="white px-3 py-4 mb-3">
    <v-layout class="hot-topics__slider" row>
      <v-flex
        v-for="(topic, index) in (topics || tmps)"
        :key="index"
        class="mr-3"
      >
        <v-card width="160px">
          <v-card-media
            class="white--text"
            height="220px"
            :src="topic.img_url | urlFilter"
          >
            <v-container
              class="bg-gradient"
              fill-height
            >
              <v-layout
                justify-center
                align-center
                fill-height
              >
                <v-flex class="text-xs-center">
                  <router-link :to="goto('TopicDetail', topic.id)" class="title white--text">{{ topic.name }}</router-link>
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
import cardSlider from '@/utils/card-slider'
import goto from '@/utils/goto'

export default {
  data: () => ({
    tmps: []
  }),
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
      // init space topics
      if (!this.topics) {
        this.tmps = Array(10).fill({
          id: 0,
          name: '',
          img_url: '@/assets/tmp.svg'
        })
        this.$store.dispatch('getHotTopics', { count: 10 })
      }
    },

    goto,
  }
}
</script>

<style scoped>
#hot-topics {
  overflow-x: hidden;
}

.bg-gradient {
  opacity: 0;
  transition: all .3s ease;
}

.bg-gradient:hover {
  background-color: rgba(0, 0, 0, .2);
  opacity: 1;
}

a.title {
  text-decoration: none;
}
</style>
