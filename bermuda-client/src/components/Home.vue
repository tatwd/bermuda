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
            fixed-tabs
            dark
          >
            <v-tab v-for="i in 3" :key="i">{{ i }}</v-tab>
          </v-tabs>
        </v-flex>
        <v-flex md4 xs12 order-xs1 order-md2>4</v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script>
export default {
  name: 'Home',
  data () {
    return {
      gradient: 'to top right, rgba(63, 81, 181, .7), ragba(25, 32, 72, .7)',
      sloganMsg: {
        title: '寻找你的寻找',
        small: '一切执于对美好校园生活的凝练'
      }
    }
  }
}
</script>

<style scoped>

</style>
