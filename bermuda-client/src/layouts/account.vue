<template>
  <div class="layout--account">
    <v-app class="account-page">
      <v-content>
        <v-container>
          <v-layout row wrap>
            <v-flex xs12 sm4 offset-sm4>
              <div class="text-xs-center">
                <v-avatar size="96px">
                  <img src="@/assets/bmd-logo.svg" alt="Bermuda Logo">
                </v-avatar>
                <h1 class="primary--text">百慕大</h1>
              </div>
              <!-- <h2>寻找你的寻找</h2> -->
            </v-flex>
            <v-flex xs12 sm4 offset-sm4>
              <router-view/>
            </v-flex>
          </v-layout>
        </v-container>
      </v-content>
    </v-app>
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

.account-page {
  background-color: transparent;
}
</style>
