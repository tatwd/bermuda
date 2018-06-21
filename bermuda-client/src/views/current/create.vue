<template>
  <v-container>
    <v-layout>
      <v-flex xs12 md8 offset-md2>
        <v-card>
          <v-card-title>
            <v-text-field
              solo
              flat
              label="标题"
              class="font-size-large"
            ></v-text-field>
          </v-card-title>
          <v-card-text>
            <div id="pell-editor" class="pell"></div>
          </v-card-text>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import initPellEditor from '@/utils/pell-editor.js'

export default {
  mounted () {
    const editor = initPellEditor(
      document.getElementById('pell-editor')
    )
  }
}
</script>

<style lang="scss">
@import '~pell/src/pell';

.pell {
  border: 0;
}

.pell-actionbar {
  font-size: 18px;
}

.pell-content {
  min-height: 500px !important;
  height: 100%;
  overflow-y: hidden;
}

.pell-content img {
  max-width: 100%;
  height: auto;
}

.font-size-large label,
.font-size-large input {
  font-size: 28px;
}
</style>
