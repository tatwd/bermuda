<template>
  <v-layout>
    <v-container grid-list-lg>
      <v-layout v-if="!product">
        <v-flex xs12>
          <v-card>
            <v-card-title>抱歉，没有该商品！</v-card-title>
          </v-card>
        </v-flex>
      </v-layout>
      <v-layout
        v-if="product"
        row wrap
      >
        <v-flex xs12>
          <v-breadcrumbs>
            <v-icon slot="divider">chevron_right</v-icon>
            <v-breadcrumbs-item :to="{ name: 'Shop' }">市场</v-breadcrumbs-item>
            <v-breadcrumbs-item disabled>{{ id }}</v-breadcrumbs-item>
          </v-breadcrumbs>
        </v-flex>
        <v-flex xs12 md5>
          <v-card>
            <v-card-media
              height="300"
              src="https://images.pexels.com/photos/121627/pexels-photo-121627.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
            ></v-card-media>
          </v-card>
        </v-flex>
        <v-flex xs12 md7>
          <v-card height="300">
            <v-card-text>
              <h1 class="headline">{{ product.title }}</h1>
              <h1 class="headline my-3 primary--text">￥{{ id }}</h1>

              <v-text-field
                type="number"
                label="数量"
                value="1"
              ></v-text-field>

              <v-btn color="info" large>加入购物车</v-btn>
              <v-btn color="success" large>购买</v-btn>
            </v-card-text>
          </v-card>
        </v-flex>
        <v-flex xs12>
          <p>详细信息</p>
        </v-flex>
      </v-layout>
    </v-container>

    <ShopCartBtn/>
  </v-layout>
</template>

<script>
import ShopCartBtn from '@/components/shop/ShopCartBtn'
import { mapGetters  } from 'vuex'

export default {
  components: {
    ShopCartBtn
  },
  data: () => ({
    id: null
  }),
  computed: {
    ...mapGetters({
      product: 'currentProduct'
    })
  },
  beforeRouteEnter (to, from, next) {
    next(vm => {
      vm.id = to.params.id
      vm.$store.dispatch('getPorductById', { id: to.params.id })
    })
  },
  watch: {
    '$route': 'fetchData'
  },
  methods: {
    fetchData () {
      this.id = this.$route.params.id
      this.$store.dispatch('getPorductById', {
        id: this.$route.params.id
      })
    }
  }
}
</script>
