<template>
  <v-card v-if="current">
    <v-card-title>
      <h1 class="mr-3">{{ current.title }}</h1>
      <span class="grey--text">
        <router-link :to="goto('UserProfile', current.user.id)">{{ current.user.name }}</router-link>
        发表于 {{ current.created_at | dateFilter }}
      </span>
    </v-card-title>
    <v-card-text>
      {{ current.text }}
    </v-card-text>
  </v-card>
</template>

<script>
import goto from '@/utils/goto'

export default {
  props: {
    current: {
      type: Object,
      default: null
    }
  },
  methods: {
    goto
  }
}
</script>
