<template>
  <div class="layout--account">
    <h2>Account Page Layout</h2>
    <canvas id="particle-animation"></canvas>
  </div>
</template>

<script>
import particleAnimation from '@/assets/js/particle-animation'

export default {
  name: 'account',
  mounted () {
    particleAnimation(document.querySelector('#particle-animation'), { color: '#fdeeeb' })
  }
}
</script>

<style scoped>
#particle-animation {
  width: 100%;
  height: 100%;

  position: absolute;
  top: 0;
  z-index: -1;
}
</style>
