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
            <div>
              <v-btn color="primary" large>加入我们</v-btn>
            </div>
          </v-flex>
        </v-layout>
      </v-container>
    </v-jumbotron>
    <v-container>
      <v-layout row wrap>
        <v-flex md8 xs12 order-xs2 order-md1>
          <v-tabs
            slider-color="primary"
            slot="extension"
            grow
            flat
            color="info"
            dark
          >
            <v-tab
              v-for="item in filterArr"
              :key="item.alias"
              @click="toggleFilter(item.alias)"
            >
              {{ item.text }}
            </v-tab>
          </v-tabs>
          <!-- notice list -->
          <!-- <NoticeList/> -->
          <notice-list
            :notices="notices"
          ></notice-list>
        </v-flex>

        <v-flex md4 xs12 order-xs1 order-md2>4</v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script>
import NoticeList from '@/shared/NoticeList'

export default {
  name: 'Home',
  components: {
    NoticeList
  },
  data () {
    return {
      gradient: 'to top right, rgba(63, 81, 181, .7), ragba(25, 32, 72, .7)',
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
    }
  },
  filters: {
  },
  watch: {
  },
  created () {
    this.fetchData()
  },
  methods: {
    fetchData () {
      this.notices = [
        { id: 1, title: 'test title 1', type: 'all' },
        { id: 2, title: 'test title 2', type: 'found' },
        { id: 3, title: 'test title 3', type: 'lost' },
        { id: 4, title: 'test title 4', type: 'found' },
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
    }
  }
}
</script>

<style scoped>

</style>
