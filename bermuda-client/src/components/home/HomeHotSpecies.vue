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
              <img :src="specie.img_url | urlFilter" :alt="specie.name">
            </v-avatar>
            {{ specie.name }}
          </v-chip>
        </a>
      </v-card-text>
    </v-card>
  </div>
</template>

<script>
import { noticeSpecieService } from '@/services'

export default {
  data: () => ({
    title: '物以类聚',
    species: [],
  }),
  created () {
    noticeSpecieService
      .getTop(10)
      .then(res => {
        this.species = res.data
      })
      .catch(err => console.log('get hot species =>', err))
  }
}
</script>
