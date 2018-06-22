<template>
  <div id="pell-editor" class="pell"></div>
</template>

<script>
import initPellEditor from '@/utils/pell-editor.js'

export default {
  model: {
    prop: 'html',
    event: 'change'
  },
  props: {
    html: {
      type: String,
      default: ''
    },
    initText: {
      type: String,
      default: '请输入正文'
    }
  },
  mounted () {
    const editor = initPellEditor(
      document.getElementById('pell-editor'),
      html => this.$emit('change', html)
    )
    editor.content.innerHTML = `<p>${this.initText}</p>`
  }
}
</script>

<style lang="scss">
// $pell-actionbar-color: #f2f2f2;
$pell-border-width: 0;
$pell-content-height: 100%;
$pell-content-padding: 8px 16px;

@import '~pell/src/pell';

.pell-actionbar {
  font-size: 16px;
  margin: $pell-content-padding;
  border-top: 1px solid $pell-border-color;
  border-bottom: 1px solid $pell-border-color;
}

.pell-content {
  min-height: 360px;

  ul, ol {
    padding-left: 15px;
  }

  img {
    max-width: 100%;
    height: auto;
  }
}
</style>
