 <template>
   <v-jumbotron
    :src="imgUrl"
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
          <div v-if="showSignBtn">
            <v-btn color="primary" to="/account/signup" large>加入我们</v-btn>
            <v-btn color="secondary" to="/account/signin" large>马上登录</v-btn>
          </div>
        </v-flex>
      </v-layout>
    </v-container>
  </v-jumbotron>
 </template>

<script>
export default {
  name: 'BmdSlogan',
  data: () => ({
    gradient: 'to top right, rgba(63, 81, 181, .5), ragba(25, 32, 72, .5)',
    sloganMsg: {
      title: '寻找你的寻找',
      small: '一切执于对美好校园生活的凝练'
    },
    imgUrl: 'https://images.pexels.com/photos/47424/pexels-photo-47424.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260',
    showSignBtn: true
  }),
  created () {
    if (this.$store.getters.currentUser) {
      setTimeout(() => (
        this.imgUrl = 'https://source.unsplash.com/random/1260x750'
      ), 100)

      this.showSignBtn = false
    }
  }
}
</script>
