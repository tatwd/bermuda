<template>
  <v-layout
    row
    wrap
  >
    <v-flex
      xs12
      v-for="i in 3"
      :key="i"
      class="mx-3 mb-3"
    >
      <v-card>
        <v-card-text>
          item {{ i }}
        </v-card-text>
      </v-card>
    </v-flex>
  </v-layout>
</template>
