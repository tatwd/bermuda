<template>
  <div id="home">
    <BmdSlogan/>
    <v-container>
      <v-layout row wrap>
        <v-flex md12 xs12>
          <BmdHotTopics/>
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
          <BmdHotSpecies/>
          <BmdHotCurrents/>
          <BmdTopUsers/>
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script>
import BmdNoticeList from '@/components/shared/BmdNoticeList'
import BmdSlogan from '@/components/home/BmdSlogan'
import BmdHotTopics from '@/components/home/BmdHotTopics'
import BmdHotSpecies from '@/components/home/BmdHotSpecies'
import BmdHotCurrents from '@/components/home/BmdHotCurrents'
import BmdTopUsers from '@/components/home/BmdTopUsers'

export default {
  // name: 'Home',
  components: {
    BmdNoticeList,
    BmdSlogan,
    BmdHotTopics,
    BmdHotSpecies,
    BmdHotCurrents,
    BmdTopUsers
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
  created () {
    this.fetchData()
  },
  methods: {
    fetchData () {
      // init test data
      this.notices = [
        {
          id: 1,
          title: 'test title 1',
          type: 'all',
          img: 'https://images.pexels.com/photos/877695/pexels-photo-877695.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260'
        },
        {
          id: 2,
          title: 'test title 2',
          type: 'found',
          img: 'https://images.pexels.com/photos/837500/pexels-photo-837500.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260'
        },
        {
          id: 3,
          title: 'test title 3',
          type: 'lost',
          img: 'https://images.pexels.com/photos/1025585/pexels-photo-1025585.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260'
        },
        {
          id: 4,
          title: 'test title 4',
          type: 'found',
          img: 'https://images.pexels.com/photos/1023949/pexels-photo-1023949.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260'
        },
      ]
      this.cacheData = this.notices
    },
    toggleFilter (value) {
      if(value === 'all') {
        this.notices = this.cacheData
        return
      }
      this.notices = this.cacheData
        .filter(x => x.type === value)
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
