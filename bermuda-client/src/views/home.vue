<template>
  <div id="home">
    <HomeSlogan/>
    <v-container>
      <v-layout row wrap>
        <v-flex md12 xs12>
          <HomeHotTopics/>
        </v-flex>

        <v-flex md7 xs12 order-xs2 order-md1>
          <v-tabs
            slider-color="primary"
            slot="extension"
            grow
            flat
          >
            <v-tab
              v-for="item in filterArr"
              :key="item.alias"
              @click="toggleFilter(item.alias)"
              class="black--text"
            >
              {{ item.text }}
            </v-tab>
          </v-tabs>
          <!-- notice list -->
          <BmdNoticeList
            :notices="notices"
          />
        </v-flex>

        <v-flex md5 xs12 order-xs1 order-md2 class="bmd--pl">
          <HomeHotSpecies/>
          <HomeHotCurrents/>
          <HomeTopUsers/>
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'

import BmdNoticeList from '@/components/shared/BmdNoticeList'
import HomeSlogan from '@/components/home/HomeSlogan'
import HomeHotTopics from '@/components/home/HomeHotTopics'
import HomeHotSpecies from '@/components/home/HomeHotSpecies'
import HomeHotCurrents from '@/components/home/HomeHotCurrents'
import HomeTopUsers from '@/components/home/HomeTopUsers'

export default {
  components: {
    BmdNoticeList,
    HomeSlogan,
    HomeHotTopics,
    HomeHotSpecies,
    HomeHotCurrents,
    HomeTopUsers
  },
  data: () => ({
    notices: null,
    cacheData: null,
    filterArr: [
      { text: '所有启示', alias: 'all' },
      { text: '寻物启示', alias: 'lost' },
      { text: '招领启示', alias: 'found' },
    ],
    filter: 'a'
  }),
  computed: mapGetters({
    allNotices: 'allNotices',
    lostNotices: 'allLostNotices',
    foundNotices: 'allFoundNotices'
  }),
  created () {
    this.fetchData()
  },
  methods: {
    fetchData () {
      // init tmp holder
      this.notices = Array(1).fill({
        id: null,
        title: 'test',
        type: 'lost',
        img_url: '@/assets/tmp.svg',
        user: {
          name: 'test'
        }
      })

      this.$store.dispatch('getAllNotices', {
        bind: () => this.notices = this.allNotices
      })
    },
    toggleFilter (value) {
      if(value === 'all') {
        this.notices = this.allNotices
        return
      } else if (value === 'lost') {
        this.notices = this.lostNotices
      } else {
        this.notices = this.foundNotices
      }
    },
  }
}
</script>

<style scoped>
.bmd--pl {
  --pl-size: 32px;

  padding-left: var(--pl-size);
}

@media (max-width: 960px) {
  .bmd--pl {
    --pl-size: 0;
  }
}
</style>
