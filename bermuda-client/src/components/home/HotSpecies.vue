<template>
  <div
    id="hot-species"
  >
    <v-card>
      <v-card-title>
        <v-icon color="primary">bookmark</v-icon>
        <span class="ml-2">{{ title }}</span>
      </v-card-title>
      <v-card-text>
        <a href="/"
          v-for="specie in species"
          :key="specie.id"
          class="d-inline-block"
        >
          <v-chip
            label
            outline
            color="primary"
          >
            <v-avatar tile>
              <img :src="specie.img_url" :alt="specie.name">
            </v-avatar>
            {{ specie.name }}
          </v-chip>
        </a>
      </v-card-text>
    </v-card>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  name: 'HotSpecies',
  data: () => ({
    title: '物以类聚'
  }),
  computed: mapGetters({
    species: 'hotNoticeSpecies'
  }),
  created () {
    this.$store.dispatch('getAllNoticeSpecies')
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#hot-species a {
  text-decoration: none;
}
</style>
