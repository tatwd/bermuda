<template>
  <v-container
    v-bind="{ [`grid-list-${breakpoint}`]: true }"
  >
    <v-layout row wrap>
      <v-flex
        v-for="x in ['test 1', 'test 2', 'test 3']"
        :key="x"
        xs4
      >
        <v-card class="my-3">
          <v-card-title>
            {{ x }}
          </v-card-title>
        </v-card>
      </v-flex>
      <v-flex
        v-for="n in 9"
        :key="n"
        xs6
        md3
        my-3
      >
        <v-card>
          <router-link :to="goto(n)">
            <v-card-media
              src="https://picsum.photos/200/300"
              height="240"
            ></v-card-media>
          </router-link>
          <v-card-text class="text-xs-center">
            <div>
              <router-link class="black--text" :to="goto(n)">{{ 'name' }}</router-link>
            </div>
            <div class="primary--text">￥{{ n }}</div>
          </v-card-text>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapGetters  } from 'vuex'

export default {
  computed: {
    breakpoint () {
      return this.$vuetify.breakpoint.name
    }
  },
  methods: {
    goto(id) {
      return {
        name: 'ProductDetail',
        params: {
          id
        }
      }
    }
  }
}
</script>
