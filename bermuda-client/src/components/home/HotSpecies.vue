<template>
  <div
    id="hot-species"
    :class="mlSize"
  >
    <v-card>
      <v-card-title>
        <v-icon color="primary">label</v-icon>
        <span class="ml-2">{{ example }}</span>
      </v-card-title>
      <v-card-text>
        <a href="/"
          v-for="i in 10"
          :key="i"
          class="d-inline-block"
        >
          <v-chip
            label
            outline
            color="primary"
          >
            <v-avatar tile>
              <img src="https://randomuser.me/portraits/men/35.jpg" alt="trevor">
            </v-avatar>
            种类 {{ i }}
          </v-chip>
        </a>
      </v-card-text>
    </v-card>
  </div>
</template>

<script>
export default {
  name: 'HotSpecies',
  data () {
    return {
      example: '物以类聚',
      mlSize: 'ml-4'
    }
  },
  mounted () {
    window.addEventListener('resize', this.onResize)
  },
  methods: {
    onResize () {
      this.mlSize = window.innerWidth <= '960' ? 'ml-0' : 'ml-4'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#hot-species a {
  text-decoration: none;
}
</style>
