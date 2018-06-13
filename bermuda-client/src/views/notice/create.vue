<template>
  <v-container>
    <h2>Notice Create</h2>
    <bmd-upload-img-panel
      v-model="image"
    ></bmd-upload-img-panel>
  </v-container>
</template>

<script>
import BmdUploadImgPanel from '@/components/shared/BmdUploadImgPanel'

export default {
  components: {
    BmdUploadImgPanel
  },
  data: () => ({
    image: null
  })
}
</script>
