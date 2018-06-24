<template>
  <v-layout row wrap>
    <v-flex
      xs12
      class="mx-3 mb-3"
      v-for="current in currents"
      :key="current.id"
    >
      <v-card>
        <v-card-title>
          <h2>
            <router-link :to="goto('CurrentDetail', current.id)">
            {{ current.title }}
            </router-link>
          </h2>
        </v-card-title>
        <v-subheader>
          {{ current.created_at | dateFilter }}
        </v-subheader>
        <v-card-text>
          <div v-html="current.brief_text + '...'"></div>
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" flat small :to="goto('CurrentDetail', current.id)">阅读更多</v-btn>
        </v-card-actions>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import { goto } from '@/utils/link'

export default {
  props: {
    currents: {
      type: Array,
      default: () => []
    }
  },
  methods: {
    goto
  }
}
</script>
