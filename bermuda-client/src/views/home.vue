<template>
  <div id="home">
    <v-jumbotron
      src="https://images.pexels.com/photos/47424/pexels-photo-47424.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
      :gradient="gradient"
      dark
    >
      <v-container fill-height>
        <v-layout align-center>
          <v-flex
            text-xs-center
            text-md-left
          >
            <h3 class="display-3">{{ sloganMsg.title }}</h3>
            <small class="display-1">{{ sloganMsg.small }}</small>
            <div v-if="!false">
              <v-btn color="primary" large>加入我们</v-btn>
              <v-btn color="secondary" large>马上登录</v-btn>
            </div>
          </v-flex>
        </v-layout>
      </v-container>
    </v-jumbotron>
    <v-container>
      <v-layout row wrap>
        <v-flex md12 xs12>
          <HotTopics/>
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
          <notice-list
            :notices="notices"
          ></notice-list>
        </v-flex>
        <v-flex md5 xs12 order-xs1 order-md2 class="bmd--pl">
          <HotSpecies/>
          <HotCurrents/>
          <TopUsers/>
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script>
import NoticeList from '@/components/shared/NoticeList'
import HotTopics from '@/components/home/HotTopics'
import HotSpecies from '@/components/home/HotSpecies'
import HotCurrents from '@/components/home/HotCurrents'
import TopUsers from '@/components/home/TopUsers'

export default {
  // name: 'Home',
  components: {
    NoticeList,
    HotTopics,
    HotSpecies,
    HotCurrents,
    TopUsers
  },
  data: () => ({
    gradient: 'to top right, rgba(63, 81, 181, .5), ragba(25, 32, 72, .5)',
    sloganMsg: {
      title: '寻找你的寻找',
      small: '一切执于对美好校园生活的凝练'
    },
    notices: null,
    cacheData: null,
    filterArr: [
      { text: '所有启示', alias: 'all' },
      { text: '寻物启示', alias: 'lost' },
      { text: '招领启示', alias: 'found' },
    ],
    filter: 'a'
  }),
  filters: {
  },
  watch: {
  },
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
