<template>
  <v-layout
    justify-center
    align-center
    row
    wrap
    class="text-xs-center"
  >
    <v-flex xs12 pb-3>
      <a
        v-for="(icon, index) in icons"
        :key="index"
        :href="icon.to"
      >
        <v-icon color="primary">{{ icon.name }}</v-icon>
      </a>
    </v-flex>
    <v-flex x12 pb-3>
      <small class="grey--text">
        Copyright &copy; 2017 - {{ new Date().getFullYear() }} 金三角团队
      </small>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
  data: () => ({
    icons: [
      { name: 'fa fa-github', to: 'https://github.com/tatwd/bermuda' }
    ]
  })
}
</script>
