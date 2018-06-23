<template>
  <div
    id="hot-currents"
    class="mt-4"
  >
    <v-card>
      <v-card-title>
        <v-icon color="primary">whatshot</v-icon>
        <span class="ml-2">{{ title }}</span>
      </v-card-title>
      <v-card-text v-if="hotCurrents.length">
        <v-list>
          <v-list-tile
            v-for="current in hotCurrents"
            :key="current.id"
            :to="goto('CurrentDetail', current.id)"
          >
            <v-list-tile-content>
              <v-list-tile-title>
                <h3 class="grey--text">{{ current.title }}</h3>
              </v-list-tile-title>
              <v-list-tile-sub-title>
                <span class="caption primary--text mr-2">@{{ current.user.name }}</span>
                <span class="caption">{{ current.praise_count }}个赞</span>
              </v-list-tile-sub-title>
            </v-list-tile-content>
          </v-list-tile>
        </v-list>
      </v-card-text>
    </v-card>
  </div>
</template>

<script>
import { currentService } from '@/services'
import { goto } from '@/utils/link'

export default {
  data: () => ({
    title: '热门动态',
    hotCurrents: []
  }),
  created () {
    currentService
      .getTop(10)
      .then(({ data }) => {
        this.hotCurrents = data
      })
      .catch(console.error)
  },
  methods: { goto }
}
</script>
