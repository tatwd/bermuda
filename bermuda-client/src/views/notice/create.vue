<template>
  <v-container>
    <v-layout>
      <v-flex xs12 md8 offset-md2>
        <NoticeCreateFrom/>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import NoticeCreateFrom from '@/components/notice/NoticeCreateForm'

export default {
  components: {
    NoticeCreateFrom
  }
}
</script>
