<template>
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
          <v-breadcrumbs-item disabled>{{ product.title }}</v-breadcrumbs-item>
        </v-breadcrumbs>
      </v-flex>
      <v-flex xs12 md5>
        <v-card>
          <v-card-media height="300" :src="product.img_url | urlFilter"></v-card-media>
        </v-card>
      </v-flex>
      <v-flex xs12 md7>
        <v-card>
          <v-card-text>
            <h1 class="headline">{{ product.title }}</h1>
            <h1 class="headline my-3 primary--text">￥{{ product.price }}</h1>
            <p>库存：{{ product.inventory }}</p>

            <v-text-field
              type="number"
              label="数量"
              v-model="quantity"
            ></v-text-field>

            <v-btn color="info" large @click="addProductToCart({product, quantity})">加入购物车</v-btn>
            <v-btn color="success" large>购买</v-btn>
          </v-card-text>
        </v-card>
      </v-flex>
      <v-flex xs12>
        <p>详细信息</p>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapGetters, mapActions  } from 'vuex'

export default {
  data: () => ({
    id: null,
    quantity: 1
  }),
  computed: {
    ...mapGetters({
      product: 'currentProduct'
    })
  },
  methods: mapActions([
    'addProductToCart'
  ])
}
</script>
