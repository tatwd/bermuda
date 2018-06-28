<template>
  <v-card v-if="!current">
    <v-card-text class="text-xs-center">
      <v-progress-circular indeterminate color="primary"></v-progress-circular>
    </v-card-text>
  </v-card>
  <v-card v-else>
    <v-card-title>
      <h1 class="mr-3">{{ current.title }}</h1>
    </v-card-title>
      <v-subheader>
        <router-link
          :to="goto('UserProfile', current.user.id)"
        >
          <v-avatar size="42">
            <img :src="current.user.avatar_url | urlFilter" :alt="current.user.name">
          </v-avatar>
          <span class="mx-2">{{ current.user.name }}</span>
        </router-link>
        发表于 {{ current.created_at | dateFilter }}
      </v-subheader>
    <v-card-text>
      <div v-html="current.text"></div>
    </v-card-text>
  </v-card>
</template>

<script>
import { goto } from '@/utils/link'

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
