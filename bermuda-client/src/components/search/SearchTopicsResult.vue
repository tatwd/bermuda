<template>
  <v-container grid-list-xs>
    <v-layout row wrap>
      <v-flex
        xs6
        md4
        v-for="topic in topics"
        :key="topic.id"
      >
        <v-card class="mx-3 mb-3">
          <v-card-media
            :src="topic.img_url"
            height="136px"
          ></v-card-media>
          <v-card-title>
            <h3>{{ topic.name }}</h3>
          </v-card-title>
          <v-card-text>
            <span class="grey--text">
              参与人数 {{ topic.join_count }}
            </span>
          </v-card-text>
          <v-card-actions>
            <v-btn color="primary" small>参与</v-btn>
          </v-card-actions>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  props: {
    topics: {
      type: Array,
      default: null
    }
  }
}
</script>

